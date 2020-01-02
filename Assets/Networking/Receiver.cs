using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;


public class Receiver : MonoBehaviour
{
    public int port = 13000;
    public Rigidbody2D blob;

    TcpListener server;
    TcpClient client;
    NetworkStream stream;
    byte[] blobData = new byte[32];

    volatile float x;
    volatile float y;
    volatile bool ready = false;

    void Start()
    {
        server = new TcpListener(IPAddress.Any, port);
        server.Start();
        new Thread(StartServer).Start();
    }

    void StartServer()
    {
        client = server.AcceptTcpClient();
        stream = client.GetStream();

        ready = client.Connected;
        while (client.Connected)
        {
            int bytesRead = stream.Read(blobData, 0, blobData.Length);
            string otherPosition = Encoding.ASCII.GetString(blobData, 0, bytesRead);
            string[] parts = otherPosition.Split('#');
            x = float.Parse(parts[0]);
            y = float.Parse(parts[1]);
        }
        ready = false;
    }

    private void FixedUpdate()
    {
        if (!ready)
            return;

        blob.MovePosition(new Vector2(x, y));
    }
}
