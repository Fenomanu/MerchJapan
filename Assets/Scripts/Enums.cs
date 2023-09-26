using System;
using UnityEngine;

public enum KINDS
{
    Stickers,
    Prints,
    Pop_sockets,
    Charms
}
[Serializable]
public struct JsonDateTime
{
    public long value;
    public static implicit operator DateTime(JsonDateTime jdt)
    {
        Debug.Log("Converted to time - " + jdt.ToString());
        return DateTime.FromFileTime(jdt.value);
    }
    public static implicit operator JsonDateTime(DateTime dt)
    {
        Debug.Log("Converted to JDT - " + dt.ToString());
        JsonDateTime jdt = new JsonDateTime();
        jdt.value = dt.ToFileTime();
        return jdt;
    }
}