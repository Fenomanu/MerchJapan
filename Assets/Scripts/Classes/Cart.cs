using System;
using System.Collections.Generic;

[Serializable]
public class Cart
{
    public int id;
    public float price;
    public List<CartItem> items;
    public JsonDateTime time;
    public Cart(float p, List<CartItem> its, JsonDateTime t)
    {
        id = ParamsBD.GetAndIncrementNextCartID();
        price = p;
        items = its;
        time = t;
    }
}

[Serializable]
public class CartItem
{
    public int pid;
    public int amm;
    public CartItem(int id, int ammount)
    {
        pid = id;
        amm = ammount;
    }
}