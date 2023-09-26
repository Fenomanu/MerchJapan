using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class CartDB
{
    public static CartTemp LoadTempCart()
    {
        return JSONStorage.ReadFromJSONObj<CartTemp>(Path.Combine(FolderNames.objects, "cart.json"));
    }

    public static void SaveTempCart(CartTemp cart)
    {
        JSONStorage.SaveToJSONObj<CartTemp>(cart, Path.Combine(FolderNames.objects, "cart.json"));
    }
    
    public static void ClearTempCart()
    {
        JSONStorage.SaveToJSONObj<CartTemp>(new CartTemp(), Path.Combine(FolderNames.objects, "cart.json"));
    }

    public static void StoreCartRegister(Cart cart)
    {
        string path = Path.Combine(FolderNames.history, string.Join("_", cart.id.ToString(), cart.time.value.ToString(), ".json"));
        JSONStorage.SaveToJSONObj<Cart>(cart, path);
    }
    public static List<Cart> LoadCartRegister()
    {
        List<Cart> carts = new List<Cart>();
        string path = JSONStorage.GetPath(FolderNames.history);
        FileInfo[] info = new DirectoryInfo(path).GetFiles();
        foreach (FileInfo file in info) {
            if(string.Equals(file.Extension, ".json"))
            {
               carts.Add(JSONStorage.ReadFromJSONObj<Cart>(Path.Combine(FolderNames.history, file.Name)));
            }
        }
        return carts;
    }
}
