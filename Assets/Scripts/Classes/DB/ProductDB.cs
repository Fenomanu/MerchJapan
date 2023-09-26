using SimpleFileBrowser;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public static class ProductDB
{
    public static List<Product> LoadAllProducts()
    {
        return JSONStorage.ReadFromJSON<Product>(Path.Combine(FolderNames.objects, "products.json"));
    }

    public static void SaveAllProducts(List<Product> products)
    {
        JSONStorage.SaveToJSON<Product>(products, Path.Combine(FolderNames.objects, "products.json"));
    }

    public static Dictionary<int,Product> LoadAllProductsDictionary()
    {
        Dictionary<int, Product> prods = new Dictionary<int, Product>();
        foreach(Product p in LoadAllProducts())
        {
            prods.Add(p.id, p);
        }
        return prods;
    }

    public static Product StoreNewProduct(string name, string originalImagePath, KeyValuePair<int, string> pg, KeyValuePair<int, string> ps, List<Product> products)
    {
        Debug.Log(pg.Value);
        Debug.Log(ps.Value);
        // Create new saga from name
        Product newProduct = new Product(name, originalImagePath, pg.Key, ps.Key);//name, originalImagePath);
        // Create saga folder for product images
        //string sagaPath = CreateSagaFolder(newProduct);
        // Store sagas Logo in sagaImages
        //if(File.Exists())
        FileBrowserHelpers.CopyFile(originalImagePath, JSONStorage.GetPath((Path.Combine(FolderNames.images, ps.Key.ToString(), newProduct.imageName))));

        //Add saga to list and save list in json
        products.Add(newProduct);
        SaveAllProducts(products.OrderBy(p => p.productGroup.id).ToList<Product>());

        //return new Saga reference
        return newProduct;
    }

    public static bool EraseProduct(Product prod, List<Product> products)
    {
        File.Delete(prod.get_image_path);
        products.Remove(prod);
        SaveAllProducts(products);
        return true;
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

    public static List<Product> LoadKindproductOrdered(KINDS kind)
    {
        List<Product> products = LoadAllProducts();
        switch (kind)
        {
            case KINDS.Stickers:
                products = products.Where(p => (p.productGroup.id == 1 || p.productGroup.id == 7)).ToList<Product>();
                break;
            case KINDS.Prints:
                products = products.Where(p => (p.productGroup.id == 2 || p.productGroup.id == 3)).ToList<Product>();
                break;
            case KINDS.Pop_sockets:
                products = products.Where(p => (p.productGroup.id == 4)).ToList<Product>();
                break;
            case KINDS.Charms:
                products = products.Where(p => (p.productGroup.id == 5||p.productGroup.id == 6)).ToList<Product>();
                break;
        }
        return products;
    }
}
