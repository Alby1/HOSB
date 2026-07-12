using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Diagnostics;

namespace HOSB;

class Server
{
    public static Socket? serverSocket;
    private static readonly List<Socket> clientSockets = [];
    private static readonly byte[] buffer = new byte[2048];
    private static Socket? current;
    private const int PORT = 7999;

    public static void SetupServer()
    {
        Debug.WriteLine("Setting up server...");
        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        serverSocket.Bind(new IPEndPoint(IPAddress.Any, PORT));
        serverSocket.Listen(0);
        serverSocket.BeginAccept(AcceptCallback, null);
        Debug.WriteLine("Server setup complete.");
    }

    public static void CloseAllSockets()
    {
        foreach (Socket socket in clientSockets)
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
        serverSocket?.Close();
    }

    private static void AcceptCallback(IAsyncResult AR)
    {
        Socket? socket;
        try
        {
            socket = serverSocket?.EndAccept(AR);
        }
        catch (Exception)
        {
            return;
        }
        clientSockets.Add(socket!);
        socket?.BeginReceive(buffer, 0, 2048, SocketFlags.None, ReceiveCallback, socket);
        Debug.WriteLine("Client connected, waiting for request...");
        serverSocket?.BeginAccept(AcceptCallback, null);
    }

    private static void ReceiveCallback(IAsyncResult AR)
    {
        current = (Socket)AR.AsyncState!;
        int received;

        try
        {
            received = current.EndReceive(AR);
        }
        catch (Exception)
        {
            Debug.WriteLine("Client forcefully disconnected.");
            current.Close();
            clientSockets.Remove(current);
            return;
        }

        byte[] data = new byte[received];
        Array.Copy(buffer, data, received);
        string message = Encoding.UTF8.GetString(data);
        Debug.WriteLine($"Got message from {current.RemoteEndPoint}: {message}");

        if(message.Contains(".mp3")) {
            Program.main?.PlaySong(message, true);
        } else if (message.Equals("stop"))
        {
            Program.main?.StopSong(false);
        } else if (message.Equals("stoplast"))
        {
            Program.main?.StopLastSong();
        }


        

        // Message handling
        if (message == "hello")
        {
            SendData(Encoding.UTF8.GetBytes("hello"));
        }
        else
        {
            SendData([0]);
        }

        current.BeginReceive(buffer, 0, 2048, SocketFlags.None, ReceiveCallback, current);
    }

    public static void SendData(byte[] data)
    {
        current?.Send(data);
    }

    public static void KickClient()
    {
        //Shutdown the socket before closing
        current?.Shutdown(SocketShutdown.Both);
        current?.Close();
        clientSockets.Remove(current!);
        Debug.WriteLine("Client disconnected.");
    }
}