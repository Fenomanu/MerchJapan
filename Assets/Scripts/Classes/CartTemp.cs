using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CartTemp
{
    public float price;
    public List<CartTempItem> items;
    public CartTemp()
    {
        price = 0;
        items = new List<CartTempItem>();
    }
    public CartTemp(float price, List<CartTempItem> items)
    {
        this.price = price;
        this.items = items;
    }
}

[Serializable]
public class CartTempItem
{
    public int id;
    public string name;
    public int groupid;
    public string group;
    public int amm;
    public string imagePath;
    public CartTempItem(int id, string name, int groupid, string group, int amm, string imagePath)
    {
        this.id = id;
        this.name = name;
        this.groupid = groupid;
        this.group = group;
        this.amm = amm;
        this.imagePath = imagePath;
    }
}
