using System;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class NamedPipeClient1 : MonoBehaviour
{
    public bool _pipe = true;
    private string PipeName;
    private NamedPipeClientStream pipeClient;

    public int _message1 { get; private set; }
    public int _message2 { get; private set; }

    void Start()
    {
        PipeName = (_pipe ? "pipe1" : "pipe2");
        pipeClient = new NamedPipeClientStream(".", PipeName, PipeDirection.In, PipeOptions.Asynchronous);
        Task.Run(() => ConnectToPipeAsync());
    }

    async Task ConnectToPipeAsync()
    {
        await pipeClient.ConnectAsync();
        Debug.Log("Connected to pipe1");

        await ReadFromPipeAsync();
    }

    async Task ReadFromPipeAsync()
    {
        byte[] buffer = new byte[256];
        while (pipeClient.IsConnected)
        {
            int bytesRead = await pipeClient.ReadAsync(buffer, 0, buffer.Length);
            if (bytesRead > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                _message1 = int.Parse(message.Split(',')[0]);
                _message2 = int.Parse(message.Split(',')[1]);
            }
        }
    }

    void OnDestroy()
    {
        pipeClient?.Close();
        pipeClient?.Dispose();
    }
}
