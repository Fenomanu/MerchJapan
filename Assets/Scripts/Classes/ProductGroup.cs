using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ProductGroup
{
    public int id;
    public string name;
    public float price;
    public ProductGroup()
    {
        id = 0;
        name = "";
        price = 0f;
    }
    public ProductGroup(int i, string n, float p)
    {
        id = i;
        name = n;
        price = p;
    }
    public ProductGroup(int i)
    {
        id = i;
    }
}
