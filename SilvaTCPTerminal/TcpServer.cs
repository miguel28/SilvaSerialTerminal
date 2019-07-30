using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace IPCLib
{
    /// <summary>
    /// Function callback prototype used to report if a IPCmessage has arrive
    /// and from which client has been received.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="message"></param>
    public delegate void MessageReceived(TCPClient client, byte[] message);
    public delegate void ClientConnectionCallback(TCPClient client);
    /// <summary>
    /// Function callback prototype used to report any error.
    /// </summary>
    /// <param name="ex"></param>
    public delegate void OnErrorCallback(Exception ex);

    public class TCPServer : TcpListener
    {
        #region private Memebers
        /// <summary>
        /// List of client connected to this server.
        /// </summary>
        private List<TCPClient> m_clients;

        /// <summary>
        /// Listener Thread.
        /// </summary>
        private Thread m_service;
        #endregion

        #region Constants
        /// <summary>
        /// Default host name used for this IPC communication.
        /// </summary>
        public const string IPC_DEFAULT_HOST = "localhost";

        /// <summary>
        /// Default port number used for this IPC communication.
        /// </summary>
        public const int IPC_DEFAULT_PORT = 9786;
        #endregion

        #region Events
        /// <summary>
        /// Event raised when a message has been received.
        /// </summary>
        public event MessageReceived MessageReceived;

        /// <summary>
        /// Event raised when an error has occurred.
        /// </summary>
        public event OnErrorCallback OnError;

        /// <summary>
        /// Event raised when the IPC server is connected
        /// </summary>
        public event EventHandler Connected;

        /// <summary>
        /// Event raised when the IPC server is disconnected 
        /// </summary>
        public event EventHandler Disconnected;

        public event ClientConnectionCallback ClientConnected;
        public event ClientConnectionCallback ClientDisconnected;
        #endregion

        #region Constructors
        /// <summary>
        ///  Defualt constructor.
        /// </summary>
        /// <param name="port"></param>
        public TCPServer(int port = IPC_DEFAULT_PORT) :
            base(IPAddress.Any, port)
        {
            m_clients = new List<TCPClient>();
        }
        #endregion


        /// <summary>
        /// Reports if the IPC is listening for new connectins.
        /// </summary>
        public bool IsListening
        {
            get;
            protected set;
        }

        public List<TCPClient> Clients
        {
            get
            {
                return m_clients;
            }
        }

        /// <summary>
        /// Method to start listening 
        /// </summary>
        public void StartServer()
        {
            if (null == m_service)
            {
                IsListening = true;

                m_service = new Thread(Listening);
                m_service.Name = "IPC Server Thread Service";
                m_service.Start();
            }
        }

        /// <summary>
        /// Method used to stop this server listening.
        /// </summary>
        public void StopServer()
        {
            if (m_service != null)
            {
                m_clients.ForEach(x => x.Stop());
                base.Stop();
                m_service.Interrupt();
                m_service.Abort();
                
                m_service = null;
                System.GC.Collect();
                IsListening = false;

                if (Disconnected != null)
                {
                    Disconnected(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Method that servers the listener thread.
        /// </summary>
        private void Listening()
        {
            TcpClient clientSocket = default(TcpClient);
            try
            {
                base.Start();

                if (Connected != null)
                {
                    Connected(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                RaiseError(ex);
            }

            while(IsListening)
            {
                try
                {
                    clientSocket = base.AcceptTcpClient();
                    TCPClient client = TCPClient.CreateSlaveClient(clientSocket, this);
                    ClientConnected?.Invoke(client);
                    lock (this)
                    {
                        m_clients.Add(client);
                    }
                    client.Start();
                    client.Disconnected += client_Disconnected;
                }
                catch(Exception ex)
                {
                    if (ex is ObjectDisposedException
                           || ex is ThreadAbortException
                           || ex is ThreadInterruptedException)
                    {
                        break;
                    }
                    else
                    {
                        RaiseError(ex);
                    }
                }
            }
            base.Stop();
        }

        /// <summary>
        /// When the client is disconnected remove fro mthe list of clients.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void client_Disconnected(object sender, EventArgs e)
        {
            ClientDisconnected?.Invoke((TCPClient)sender);
            lock (this)
            {
                m_clients.Remove((TCPClient)sender);
            }
        }

        /// <summary>
        /// Method used to raise and error
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
        /// Raise event when receive message for any of the clients connected 
        /// to this server,
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message"></param>
        public void ReceivedClientMessage(TCPClient client, byte[] message)
        {
            if (MessageReceived != null)
            {
                MessageReceived(client, message);
            }
        }

        public void SendMessageToAllClients(byte[] msg)
        {
            m_clients.ForEach( (x) => x.SendMessage(msg) );
        }

        public void SendMessageToAllClients(string msg)
        {
            byte[] data = ASCIIEncoding.Default.GetBytes(msg);
            SendMessageToAllClients(data);
        }
    }
}

