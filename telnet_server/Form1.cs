using System.Net.Sockets;
using System.Net;
using System.Text;

namespace telnet_server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private bool isListening = false; // biến để đại diện cho trạng thái của nút lắng nghe
        private Socket listenerSocket;
        private IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("192.168.83.198"), 8080);
        private List<Socket> ListClient;


        private void btnNghe_Click(object sender, EventArgs e)
        {
            if (!isListening)
            {
                isListening = true;
                btnNghe.Text = "Listening";
                lvMess.Items.Add(new ListViewItem("Server chạy trên 192.168.83.198:8080. Đang lắng nghe kết nối...\r\n"));
                StartUnsafeThread();
            }
            else
            {
                isListening = false;
                btnNghe.Text = "Listen";
                lvMess.Items.Add(new ListViewItem("Ngừng lắng nghe kết nối và đóng Server!\r\n"));
                btnNghe.Enabled = false;
                foreach (Socket socket in ListClient)
                {
                    socket.Send(Encoding.ASCII.GetBytes("Disconnected!"));
                }
                MessageBox.Show("Kết nối bị đóng bởi server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listenerSocket.Close();
            }

        }

        void StartUnsafeThread()
        {
            ListClient = new List<Socket>();
            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenerSocket.Bind(ipepServer);
            Thread listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        listenerSocket.Listen(100);
                        Socket client1 = listenerSocket.Accept();
                        ListClient.Add(client1);
                        string str = "Client mới kết nối từ: " + client1.RemoteEndPoint.ToString() + "\n";
                        lvMess.Items.Add(new ListViewItem(str));
                        Thread recei = new Thread(receive);
                        recei.IsBackground = true;
                        recei.Start(client1);
                    }
                }
                catch
                {
                    ipepServer = new IPEndPoint(IPAddress.Parse("192.168.101.45"), 8080);
                    listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }
            });
            listen.IsBackground = true;
            listen.Start();
        }

        void receive(object obj)
        {
            Socket client = obj as Socket;
            Byte[] data = new byte[1024 * 5000];
            while (true)
            {
                if (isListening)
                {
                    int receivedBytes = client.Receive(data);
                    if (receivedBytes == 0)
                    {
                        // Kết nối đã đóng
                        break;
                    }
                    string str = Encoding.ASCII.GetString(data, 0, receivedBytes);
                    string content = client.RemoteEndPoint.ToString() + ": " + str + "\n";
                    lvMess.Items.Add(new ListViewItem(content));

                    Byte[] Sended = System.Text.Encoding.UTF8.GetBytes(content);
                    int length_send = Sended.Length;

                    foreach (Socket socket in ListClient)
                    {
                        if (socket != client)
                        {
                            socket.Send(Sended, length_send, SocketFlags.None);
                        }
                    }
                    // Reset lại buffer
                    Array.Clear(data, 0, data.Length);
                }
                else
                {
                    // Kết nối đã đóng
                    break;
                }
            }
        }

        private void Bai05_Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Socket socket in ListClient)
            {
                socket.Send(UTF32Encoding.UTF32.GetBytes("Server ngừng kết nối!"));
            }

            if (isListening)
                MessageBox.Show("Kết nối bị đóng bởi server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            foreach (Socket socket in ListClient)
            {
                socket.Close();
            }

            listenerSocket.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mess = "KPhuong: " + textBox1.Text + "\n";
            lvMess.Items.Add(new ListViewItem(mess));

            Byte[] Sended = System.Text.Encoding.UTF8.GetBytes(mess);
            int length_send = Sended.Length;

            foreach (Socket socket in ListClient)
            {
                 socket.Send(Sended, length_send, SocketFlags.None);
            }
            textBox1.Text = string.Empty;
        }
    }
}