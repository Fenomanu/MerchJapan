using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public static class Utilities
{

    public static Sprite LoadImage(string filePath)
    {
        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
            Debug.Log("File " + filePath + " exists");
        }
        else
        {
            Debug.Log("File " + filePath + " does not exist");
        }
        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), Vector2.one * 0.5f);
        return sprite;
    }
    public static IEnumerator LoadImageThread(string filePath, Image image)
    {
        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            yield return null;
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
            yield return null;
            //Debug.Log("File " + filePath + " exists");
        }
        else
        {
            Debug.Log("File " + filePath + " does not exist");
        }
        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), Vector2.one * 0.5f);
        if(image != null) image.sprite = sprite;
        yield return null;
    }
    public static Sprite CloneImageIntoCats(string filePath)
    {
        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        else
        {
            Debug.Log("File " + filePath + " does not exist");
        }
        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), Vector2.one * 0.5f);
        return sprite;
    }
}
