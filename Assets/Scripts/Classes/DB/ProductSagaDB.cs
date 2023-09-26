using SimpleFileBrowser;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ProductSagaDB
{
    public static List<ProductSaga> LoadAllProductSagas()
    {
        return JSONStorage.ReadFromJSON<ProductSaga>(Path.Combine(FolderNames.objects, "sagas.json"));
    }

    public static void SaveAllProductSagas(List<ProductSaga> sagas)
    {
        JSONStorage.SaveToJSON<ProductSaga>(sagas, Path.Combine(FolderNames.objects, "sagas.json"));
    }

    public static Dictionary<int, string> LoadProductSagasDictionary()
    {
        Dictionary<int, string> dict = new Dictionary<int, string>();
        foreach(ProductSaga p in LoadAllProductSagas())
        {
            dict.Add(p.id, p.name);
        }
        return dict;
    }
    public static Dictionary<int, ProductSaga> LoadFullProductSagasDictionary()
    {
        Dictionary<int, ProductSaga> dict = new Dictionary<int, ProductSaga>();
        foreach (ProductSaga p in LoadAllProductSagas())
        {
            dict.Add(p.id, p);
        }
        return dict;
    }

    public static ProductSaga StoreNewSaga(string name, List<ProductSaga> sagas)
    {
        // Create new saga from name
        ProductSaga newSaga = new ProductSaga(name);
        // Create saga folder for product images
        string sagaPath = CreateSagaFolder(newSaga);
        // Store sagas Logo in sagaImages
        //if(File.Exists())
        //Add saga to list and save list in json
        sagas.Add(newSaga);
        SaveAllProductSagas(sagas);

        //return new Saga reference
        return newSaga;
    }

    public static bool EraseSaga(ProductSaga saga, List<ProductSaga> sagas)
    {
        if(EraseFolder(saga.folderName))
        {
            sagas.Remove(saga);
            SaveAllProductSagas(sagas);
            return true;
        }
        return false;
    }

    private static string CreateSagaFolder(ProductSaga saga)
    {
        string path = JSONStorage.GetPath(Path.Combine(FolderNames.images, saga.folderName));
        if (!Directory.Exists(path)) 
        {
            Directory.CreateDirectory(path);
            return path;
        }
        return "";
    }
    public static bool EraseFolder(string folderName)
    {
        string path = JSONStorage.GetPath(Path.Combine(FolderNames.images, folderName));
        if (Directory.GetFiles(path).Length > 0)
        {
            return false;
        }
        Directory.Delete(path);
        return true;
    }
}
