using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ProductGroupDB
{
    public static List<ProductGroup> LoadAllProductGroups()
    {
        return JSONStorage.ReadFromJSON<ProductGroup>(Path.Combine(FolderNames.objects, "groups.json"));
    }

    public static void SaveAllProductGroups(List<ProductGroup> groups)
    {
        JSONStorage.SaveToJSON<ProductGroup>(groups, Path.Combine(FolderNames.objects, "groups.json"));
    }

    public static Dictionary<int, string> LoadProductGroupsDictionary()
    {
        Dictionary<int, string> dict = new Dictionary<int, string>();
        foreach(ProductGroup p in LoadAllProductGroups())
        {
            dict.Add(p.id, p.name);
        }
        return dict;
    }

    public static Dictionary<int, ProductGroup> LoadFullProductGroupsDictionary()
    {
        Dictionary<int, ProductGroup> dict = new Dictionary<int, ProductGroup>();
        foreach(ProductGroup p in LoadAllProductGroups())
        {
            dict.Add(p.id, p);
        }
        return dict;
    }
}
