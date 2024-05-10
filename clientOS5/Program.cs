using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

public class TcpClientSample
{
    public static void Main()
    {
        int port;
        TcpClient server;

        Console.WriteLine(" port number :");
        port = Int32.Parse(Console.ReadLine());
        try
        {
            server = new TcpClient("127.0.0.1", port);
        }
        catch (SocketException)
        {
            Console.WriteLine("Unable to connect to server");
            return;
        }
        Console.WriteLine("Connected to the Server...");

        NetworkStream ns = server.GetStream();


        byte[] fileData = File.ReadAllBytes(@"E:\uni\yekparche\songs.csv"); 

        ns.Write(fileData, 0, fileData.Length);
        ns.Flush();

        Console.WriteLine("File sent to the server...");

        Console.WriteLine("Disconnecting from server...");
        ns.Close();
        server.Close();
    }
}

