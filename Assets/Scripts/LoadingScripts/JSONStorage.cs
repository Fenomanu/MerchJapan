using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Linq;
using System.IO;

public static class JSONStorage
{
    public static void SaveToJSON<T>(List<T> toSave, string filename)
    {
        //Debug.Log(GetPath(filename));
        string content = JsonHelper.ToJson<T>(toSave.ToArray());
        WriteFile(GetPath(filename), content);
    }
    
    public static List<T> ReadFromJSON<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));
        if(string.IsNullOrEmpty(content) || content == "{}")
        {
            return new List<T>();
        }
        List<T> res = JsonHelper.FromJson<T>(content).ToList();
        return res;
    }

    public static void SaveToJSONObj<T>(T toSave, string filename)
    {
        //Debug.Log(GetPath(filename));
        string content = JsonUtility.ToJson(toSave);
        WriteFile(GetPath(filename), content);
    }

    public static T ReadFromJSONObj<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));
        //if (string.IsNullOrEmpty(content) || content == "{}")
        //{
        //    return;
        //}
        T res = JsonUtility.FromJson<T>(content);
        return res;
    }

    public static string GetPath(string fileName)
    {
        return Path.Combine(Application.persistentDataPath, fileName);
    }
    public static void WriteFile(string path, string content)
    {
        FileStream fs = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fs))
        {
            writer.Write(content);
        }
    }

    public static string ReadFile(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader rd = new StreamReader(path))
            {
                string content = rd.ReadToEnd();
                return content;
            }
        }
        return "";
    }

    public static void WriteFileInResources(string path, string content)
    {
        FileStream fs = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fs))
        {
            writer.Write(content);
        }
        using (StreamWriter writer = new StreamWriter(fs))
        {
            writer.Write(content);
        }
    }
}
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
public static class JsonFiles
{

    public static void CreateParams()
    {

    }
    public static void CreateGroups()
    {

    }
    public static void CreateProducts()
    {

    }
    public static void CreateSagas()
    {

    }
}
