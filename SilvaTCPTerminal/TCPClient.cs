using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace IPCLib
{
    public class TCPClient : IDisposable
    {
        #region Private members
        /// <summary>
        /// Instance of TcpClient of .NET definition.
        /// </summary>
        private TcpClient m_client;

        /// <summary>
        /// Instance of IPC server in case of the actual application is behaving 
        /// as server.
        /// </summary>
        private TCPServer m_server;

        /// <summary>
        /// Client host name
        /// </summary>
        private string m_host = TCPServer.IPC_DEFAULT_HOST;

        /// <summary>
        /// Client conection port.
        /// </summary>
        private int m_port = TCPServer.IPC_DEFAULT_PORT;

        /// <summary>
        /// Internal thread for serve this client, in reception buffer.
        /// </summary>
        private Thread m_service;

        /// <summary>
        /// Private receive buffer.
        /// </summary>
        private byte[] RecvBuffer;
        
        /// <summary>
        /// Flag to check if the client is already closed.
        /// </summary>
        private bool m_closed = false;

        /// <summary>
        /// Default Size of receive buffer.
        /// </summary>
        private const int REV_BUFFER_SIZE = 1024 * 48;
        #endregion

        #region Contructors
        /// <summary>
        /// Private contructor of a IPC Client used for create IPC communication
        /// for a client application.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        private TCPClient(string host = TCPServer.IPC_DEFAULT_HOST,int port = TCPServer.IPC_DEFAULT_PORT)
        {
            m_client = new TcpClient();
            m_host = host;
            m_port = port;
            RecvBuffer = new byte[REV_BUFFER_SIZE];
        }

        /// <summary>
        /// Private contructor of a IPC Client used for create IPC communication
        /// for a server application.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="server"></param>
        private TCPClient(TcpClient client, TCPServer server)
        {
            m_client = client;
            m_server = server;
            RecvBuffer = new byte[REV_BUFFER_SIZE];
        }

        /// <summary>
        /// Static method to create a IPC Client instance used for create IPC communication
        /// for a client application.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static TCPClient CreateApplicationClient(string host = TCPServer.IPC_DEFAULT_HOST, int port = TCPServer.IPC_DEFAULT_PORT)
        {
            return new TCPClient(host, port);
        }

        /// <summary>
        ///  Static method to create a IPC Client instance used for create IPC communication
        /// for a server application.
        /// 
        /// This method will used only when the TCPServer application accepts a new client.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        public static TCPClient CreateSlaveClient (TcpClient client, TCPServer server)
        {
            return new TCPClient(client, server);
        }
        #endregion

        #region Public Events
        /// <summary>
        /// Event raised when a IPC message is received
        /// </summary>
        public event MessageReceived MessageReceived;

        /// <summary>
        /// Event raised when an error has occured in the comunicaiton.
        /// </summary>
        public event OnErrorCallback OnError;

        /// <summary>
        /// Event raised when this TCPClient has been connected.
        /// </summary>
        public event EventHandler Connected;

        /// <summary>
        /// Event raised when this TCPClient has been disconnected.
        /// </summary>
        public event EventHandler Disconnected;
        #endregion

        #region Public methods
        /// <summary>
        /// Propertly to know is the client is running or not.
        /// </summary>
        public bool IsRunning
        {
            get;
            protected set;
        }

        /// <summary>
        /// Function to start the connection of the IPC client
        /// to the server.
        /// </summary>
        public void Start()
        {
            if ((null == m_service) && (!IsRunning))
            {
                if (m_closed)
                {
                    m_client = new TcpClient();
                    m_closed = false;
                }

                if (!m_client.Connected)
                {
                    CreateConnection();
                }

                IsRunning = m_client.Connected;

                if (IsRunning)
                {
                    m_service = new Thread(ClientService);
                    m_service.Name = "TCP Client Thread Service";
                    m_service.Start(); 
                }
            }
        }

        /// <summary>
        /// Function to stop the connection of the IPC client
        /// drom the server.
        /// </summary>
        public void Stop()
        {
            if ( (m_service != null) && (IsRunning))
            {
                if (Disconnected != null)
                {
                    Disconnected(this, EventArgs.Empty);
                }

                m_service.Interrupt();
                m_service = null;
                System.GC.Collect();
                m_client.Close();
                m_closed = true;

                IsRunning = false;
            }
        }

        /// <summary>
        /// Methos used to send an IPC Message to the server.
        /// </summary>
        /// <param name="msg"></param>
        public void SendMessage (byte[] msg)
        {
            lock (this)
            {
                try
                {
                    if (IsRunning)
                    {
                        NetworkStream stream = m_client.GetStream();
                        stream.BeginWrite(msg, 0, msg.Length, null, null);
                    }
                }
                catch (Exception ex)
                {
                    RaiseError(ex);
                }
            }
        }

        /// <summary>
        /// Method to raise OnError event
        /// </summary>
        /// <param name="ex"></param>
        public void RaiseError(Exception ex)
        {
            if (OnError != null)
            {
                OnError(ex);
            }
            else
            {
                throw ex;
            }
        }

        /// <summary>
        /// Dispose the object
        /// </summary>
        public void Dispose()
        {
            Stop();
        }

        /// <summary>
        /// Check is this object is disposed.
        /// </summary>
        public bool IsDisposed
        {
            get;
            private set;
        }

        public override string ToString()
        {
            try
            {
                return string.Format("TCP Client: {0}", this.m_client.Client.RemoteEndPoint.ToString());
            }
            catch
            {
                return string.Format("TCP Client: disposed");
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Private mthos to try start a connection to the server.
        /// </summary>
        private void CreateConnection()
        {
            try
            {
                var result = m_client.BeginConnect(m_host, m_port, null, null);
                result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(250));

                if (m_client.Connected)
                {
                    m_client.EndConnect(result);
                    if (Connected != null)
                    {
                        Connected(this, EventArgs.Empty);
                    }
                }
                else
                {
                    result.AsyncWaitHandle.Dispose();
                    throw new TimeoutException("Connection Timeout occurred. The target device does not respond after " + (250).ToString() + " milliseconds");
                }
            }
            catch (Exception ex)
            {
                if (ex is TimeoutException)
                {
                    throw ex;
                }
                else
                {
                    RaiseError(ex);
                }
                
            }
        }

        /// <summary>
        /// Thread that manages the reception of message
        /// </summary>
        private void ClientService()
        {
            NetworkStream networkStream = m_client.GetStream();

            while (IsRunning)
            {
                try
                {
                    int bytes = networkStream.Read(RecvBuffer, 0, REV_BUFFER_SIZE);

                    try
                    {
                        if (bytes > 0)
                        {
                            byte[] rawMessage = new byte[bytes];
                            Array.Copy(RecvBuffer, rawMessage, bytes);

                            // Report to server is get a message
                            if (m_server != null)
                            {
                                m_server.ReceivedClientMessage(this, rawMessage);
                            }

                            // Report a message to client
                            if (MessageReceived != null)
                            {
                                MessageReceived(this, rawMessage);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        RaiseError(ex);
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }
            Stop();
        }
        #endregion

    }
}
