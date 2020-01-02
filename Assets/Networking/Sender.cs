using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class Sender : MonoBehaviour
{
    public int port = 13000;
    public string server = "127.0.0.1";
    public Rigidbody2D blob;

    TcpClient client;
    NetworkStream stream;

    void ConnectToServer()
    {
        client = new TcpClient(server, port);
        stream = client.GetStream();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ConnectToServer();
        }
        else if (client == null)
        {
            return;
        }
        else
        {
            byte[] serializedPosition = Encoding.ASCII.GetBytes($"{blob.position.x}#{blob.position.y}");
            stream.Write(serializedPosition, 0, serializedPosition.Length);
        }
    }
}
