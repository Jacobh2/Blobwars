using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class Sender : MonoBehaviour
{
    public int port = 13000;
    public string server = "127.0.0.1";
    TcpClient client;
    NetworkStream stream;
    public Rigidbody2D blob;

    void ConnectToServer()
    {
        Debug.Log($"About to connect to server...");
        client = new TcpClient(server, port);
        Debug.Log($"Connected To Server");
        stream = client.GetStream();
    }

    // Update is called once per frame
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
            Debug.Log($"About to send positoin");
            byte[] serializedPosition = Encoding.ASCII.GetBytes($"{blob.position.x}#{blob.position.y}");
            stream.Write(serializedPosition, 0, serializedPosition.Length);
            Debug.Log($"Position sent");
        }
    }
}
