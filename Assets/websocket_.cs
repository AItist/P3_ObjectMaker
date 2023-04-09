using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class websocket_ : MonoBehaviour
{
    private WebSocket _webSocket;
    public string _serverUrl = "ws://localhost:8081"; // replace with your WebSocket URL
    public bool resend = false;

    private void Start()
    {
        _webSocket = new WebSocket(_serverUrl);
        _webSocket.OnOpen += OnOpen;
        _webSocket.OnMessage += OnMessage;
        _webSocket.OnClose += OnClose;
        _webSocket.OnError += OnError;
        _webSocket.Connect();
    }

    private void OnDestroy()
    {
        _webSocket.Close();
    }

    private void OnOpen(object sender, EventArgs e)
    {
        Debug.Log("WebSocket opened.");
    }

    private void OnMessage(object sender, MessageEventArgs e)
    {
        Debug.Log("WebSocket message received: " + e.Data);

        if (resend)
        {
            _webSocket.Send("hello data");
        }
    }

    private void OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log("WebSocket closed.");
    }

    private void OnError(object sender, ErrorEventArgs e)
    {
        Debug.LogError("WebSocket error: " + e.Message);
    }

    public void SendMessage(string message)
    {
        _webSocket.Send(message);
    }
}
