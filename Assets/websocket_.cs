using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;
using WebSocketSharp;
using Newtonsoft.Json;
using System.IO;
using System.IO.Compression;
using ErrorEventArgs = WebSocketSharp.ErrorEventArgs;
using Newtonsoft.Json.Linq;

//using ErrorEventArgs 
using System;
using System.Linq;
//using Emgu.CV;
//using Emgu.CV.Structure;
using System.Drawing;


public class websocket_ : MonoBehaviour
{
    private WebSocket _webSocket;
    public string _serverUrl = "ws://localhost:8081"; // replace with your WebSocket URL
    public bool resend = false;

    //public SpriteRenderer tester;
    //public Sprite recovered;
    //private Image<Bgr, byte> bgr_image;
    public Image tester_image;

    private byte[] decompressedData;

    private void Start()
    {
        _webSocket = new WebSocket(_serverUrl);
        _webSocket.OnOpen += OnOpen;
        _webSocket.OnMessage += OnMessage;
        _webSocket.OnClose += OnClose;
        _webSocket.OnError += OnError;
        _webSocket.Connect();
    }

    private void Update()
    {
        if (decompressedData == null) { return; }

        //tester_image.sprite = recovered;
        int width = 640;
        int height = 480;
        int depth = 3;
        //byte[] imageData = decompressedData; // Modify this line if the decompressedData needs further processing
        //int pixelSize = 3; // Assuming 3 bytes per pixel (RGB format)
        //byte[] pixelBuffer = new byte[width * height * pixelSize];

        //byte[,,] imageData = new byte[height, width, depth];

        //int index = 0;
        //for (int y = 0; y < height; y++)
        //{
        //    for (int x = 0; x < width; x++)
        //    {
        //        for (int z = 0; z < depth; z++)
        //        {
        //            imageData[y, x, z] = (byte)decompressedData[index];
        //            index++;
        //        }
        //    }
        //}

        //Debug.Log()

        //byte[] rebatchData = new byte[height * width * depth];

        //for (int i = 0; i < decompressedData.Length; i++)
        //{

        //}

        // Step 3: Create a new Texture2D and load the decompressed data
        Texture2D recoveredTexture = new Texture2D(width, height, TextureFormat.RGB24, false);
        //recoveredTexture.LoadRawTextureData(imageData);
        //recoveredTexture.LoadImage(imageData);
        recoveredTexture.LoadRawTextureData(decompressedData);
        recoveredTexture.Apply();

        // Step 4: Create a sprite from the recovered Texture2D
        Sprite recoveredSprite = Sprite.Create(recoveredTexture, new Rect(0, 0, recoveredTexture.width, recoveredTexture.height), new Vector2(0.5f, 0.5f));

        tester_image.sprite = recoveredSprite;

        //Debug.Log(bgr_image);

        //int width = 640;
        //int height = 480;
        //int depth = 3;

        //byte[,,] imageData = new byte[height, width, depth];

        //int index = 0;
        //for (int y = 0; y < height; y++)
        //{
        //    for (int x = 0; x < width; x++)
        //    {
        //        for (int z = 0; z < depth; z++)
        //        {
        //            imageData[y, x, z] = (byte)decompressedData[index];
        //            index++;
        //        }
        //    }
        //}

        ////// Convert the 3D array to an Image<Bgr, byte> type.
        ////bgr_image = new Image<Bgr, byte>(imageData);
        //////Debug.Log(bgr_image);

        //Texture2D texture = new Texture2D(width, height);
        //for (int i = 0; i < width; i++)
        //{
        //    for (int j = 0; j < height; j++)
        //    {
        //        //Bgr color = bgr_image[j, i];
        //        texture.SetPixel(i, j, new UnityEngine.Color(1f, 1f, 1f));
        //    }
        //}

        //texture.Apply();

        //// Convert the Texture2D to Sprite
        //Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        //// Assign the Sprite to the Image component.
        //tester_image.sprite = sprite;
    }

    private void OnDestroy()
    {
        _webSocket.Close();
    }

    private void OnOpen(object sender, EventArgs e)
    {
        Debug.Log("WebSocket opened.");
    }

    private void ConvertData(string data)
    {
        // Step 1: Decode the Base64 encoded data
        byte[] encodedData = Convert.FromBase64String(data);

        // Step 2: Decompress the decoded data using GZip
        //byte[] decompressedData;
        using (MemoryStream compressedStream = new MemoryStream(encodedData))
        {
            using (MemoryStream decompressedStream = new MemoryStream())
            {
                using (GZipStream gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                {
                    gzipStream.CopyTo(decompressedStream);
                }
                decompressedData = decompressedStream.ToArray();

                Debug.Log(decompressedStream.Length.ToString());
            }
        }

        //// Step 3: Convert the decompressed byte array back into a numpy.ndarray
        //// Assuming the original numpy.ndarray was in RGB format with shape (480, 640, 3)
        //int width = 640;
        //int height = 480;
        //int depth = 3;

        //byte[,,] imageData = new byte[height, width, depth];

        //int index = 0;
        //for (int y = 0; y < height; y++)
        //{
        //    for (int x = 0; x < width; x++)
        //    {
        //        for (int z = 0; z < depth; z++)
        //        {
        //            imageData[y, x, z] = (byte)decompressedData[index];
        //            index++;
        //        }
        //    }
        //}

        //// Convert the 3D array to an Image<Bgr, byte> type.
        //bgr_image = new Image<Bgr, byte>(imageData);
        //Debug.Log(bgr_image);
        // ---------------------------------------------------------
        // ---------------------------------------------------------
        // ---------------------------------------------------------

        //byte[] imageData = decompressedData; // Modify this line if the decompressedData needs further processing
        //int pixelSize = 3; // Assuming 3 bytes per pixel (RGB format)
        //byte[] pixelBuffer = new byte[width * height * pixelSize];

        //// Step 3: Create a new Texture2D and load the decompressed data
        //Texture2D recoveredTexture = new Texture2D(width, height, TextureFormat.RGB24, false);
        //recoveredTexture.LoadRawTextureData(decompressedData);
        //recoveredTexture.Apply();

        //// Step 4: Create a sprite from the recovered Texture2D
        //Sprite recoveredSprite = Sprite.Create(recoveredTexture, new Rect(0, 0, recoveredTexture.width, recoveredTexture.height), new Vector2(0.5f, 0.5f));

        ////// Now you can use the recovered sprite as needed
        ////// For example, assign it to a SpriteRenderer component
        ////SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        ////spriteRenderer.sprite = recoveredSprite;
        //if (recoveredSprite != null)
        //{
        //    recovered = recoveredSprite;
        //}
        ////tester_image.sprite = recoveredSprite;
        ///


        //for (int y = 0; y < height; y++)
        //{
        //    for (int x = 0; x < width; x++)
        //    {
        //        int inputIndex = y * width * pixelSize + x * pixelSize;
        //        int outputIndex = (height - y - 1) * width * pixelSize + x * pixelSize; // Flipping vertically
        //        Array.Copy(imageData, inputIndex, pixelBuffer, outputIndex, pixelSize);
        //    }
        //}

        //// Step 4: Use the recovered numpy.ndarray to create an image in C#
        //Texture2D recoveredTexture = new Texture2D(width, height, TextureForm)
        //using (Bitmap image = new Bitmap(width, height, PixelFormat.Format24bppRgb))
        //{
        //    Rectangle rect = new Rectangle(0, 0, width, height);
        //    BitmapData bmpData = image.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
        //    IntPtr ptr = bmpData.Scan0;
        //    System.Runtime.InteropServices.Marshal.Copy(pixelBuffer, 0, ptr, pixelBuffer.Length);
        //    image.UnlockBits(bmpData);

        //    // Now you can use the image as needed, e.g., save it to a file
        //    image.Save("recovered_image.jpg", ImageFormat.Jpeg);
        //}
    }

    private void OnMessage(object sender, MessageEventArgs e)
    {
        //Debug.Log($"{_serverUrl} WebSocket message received: " + e.Data);
        
        try
        {
            DataModel data = JsonConvert.DeserializeObject<DataModel>(e.Data);

            //Debug.Log("Received JSON Data: " + data);
            //Debug.Log($"data.index : {data.index}");
            //Debug.Log($"data.ret : {data.ret}");
            //Debug.Log($"data.frame : {data.frame}");
            ConvertData(data.frame);
        }
        catch (Exception ex)
        {
            Debug.LogError("Error parsing JSON data: " + ex.Message);
        }

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

public class DataModel
{
    public int index { get; set; }
    public bool ret { get; set; }
    public string frame { get; set; }
}