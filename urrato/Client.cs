using System.Net;
using System.Text;
using System.Net.Sockets;

namespace HOSB;

class Client
{
    private static readonly Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    private const int PORT = 7999;

    public static void Mario(string[] args)
    {
        Console.Title = "Client";
        ConnectToServer();
        RequestLoop();
        Exit();
    }

    private static void ConnectToServer()
    {
        int attempts = 0;
        while (!clientSocket.Connected)
        {
            try
            {
                attempts++;
                Console.WriteLine("Connection attempt " + attempts);
                // Change IPAddress.Loopback to a remote IP to connect to a remote host
                clientSocket.Connect(IPAddress.Loopback, PORT);
            }
            catch (Exception)
            {
                Console.Clear();
            }
        }

        Console.Clear();
        Console.WriteLine("Connected");
    }

    private static void RequestLoop()
    {
        Console.WriteLine("Type \"exit\" to disconnect.");

        while (true)
        {
            SendRequest();
            ReceiveResponse();
        }
    }

    //Close socket and exit the program
    private static void Exit()
    {
        byte[] data = Encoding.UTF8.GetBytes("exit"); // Convert string to byte[] to send
        clientSocket.Send(data, 0, data.Length, SocketFlags.None);
        clientSocket.Shutdown(SocketShutdown.Both);
        clientSocket.Close();
        Environment.Exit(0);
    }

    private static void SendRequest()
    {
        Console.Write("Send a request: ");
        string request = Console.ReadLine()!;
        while (string.IsNullOrEmpty(request) || string.IsNullOrWhiteSpace(request))
        {
            Console.WriteLine("Invalid command.");
            Console.Write("Send a request: ");
            request = Console.ReadLine()!;
        }
        byte[] data = Encoding.UTF8.GetBytes(request);
        clientSocket.Send(data, 0, data.Length, SocketFlags.None);

        if (request.ToLower() == "exit")
        {
            Exit();
        }
    }

    private static void ReceiveResponse()
    {
        byte[] buffer = new byte[2048];
        clientSocket.Receive(buffer, SocketFlags.None);
        string message = Encoding.UTF8.GetString(buffer);
        Console.WriteLine($"Received message from server: {message}");
    }
}