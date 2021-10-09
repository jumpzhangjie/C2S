using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;


public class Client : MonoBehaviour
{
    private Socket tcpclient;
    private string serverip = "127.0.0.1";
    private int serverport = 5000;



    // Start is called before the first frame update
    void Start()
    {
        //创建一个socket对象
        tcpclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //绑定ip和端口
        IPAddress ipaddr = IPAddress.Parse(serverip);
        EndPoint end = new IPEndPoint(ipaddr, serverport);
        tcpclient.Connect(end);
        Debug.Log("请求服务器连接");

        byte[] servdata = new byte[1024];
        int length = tcpclient.Receive(servdata);
        string mess2 = Encoding.UTF8.GetString(servdata, 0, length);
        Debug.Log("客户端收到服务器发送了一条消息：" + mess2);

        string mess = "Hello Server";
        var data = Encoding.UTF8.GetBytes(mess);
        tcpclient.Send(data);
        Debug.Log("客户端向服务器发送了一条消息：" + mess);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
