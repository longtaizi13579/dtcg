using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageLoader
{
    public static Sprite LoadImage(string imgPath)
    {
        var filePath = Application.streamingAssetsPath + imgPath;
        byte[] pngBytes;
        if (Application.platform == RuntimePlatform.Android)
        {
            pngBytes = getAndroidImageBuffer(imgPath);
        }
        else
        {
            pngBytes = System.IO.File.ReadAllBytes(filePath);
        }

        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(pngBytes);
        Sprite fromTex = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        return fromTex;
    }
    static byte[] getAndroidImageBuffer(string imgPath)
    {
        var filePath = Application.streamingAssetsPath + imgPath;
        UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(filePath);
        www.SendWebRequest();
        while (!www.isDone)
        {
        }
        return www.downloadHandler.data;
    }

}