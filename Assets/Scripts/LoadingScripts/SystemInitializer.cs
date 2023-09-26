using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SystemInitializer : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
        // Preparation of file system
        // Main directories creation
        string path = JSONStorage.GetPath(FolderNames.objects);
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        path = JSONStorage.GetPath(FolderNames.images);
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        path = JSONStorage.GetPath(FolderNames.history);
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        // Secondary directories creation
        //path = JSONStorage.GetPath(Path.Combine("Objects", ""));
        //if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        //path = JSONStorage.GetPath("Objects");
        //if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        // Essential files check
        path = JSONStorage.GetPath(Path.Combine(FolderNames.objects, "params.json"));
        if (!File.Exists(path))
        {
            ParamsBD.SaveParams(new Params());
        }
        path = JSONStorage.GetPath(Path.Combine(FolderNames.objects, "products.json"));
        if (!File.Exists(path)) File.Create(path);
        path = JSONStorage.GetPath(Path.Combine(FolderNames.objects, "groups.json"));
        if (!File.Exists(path))
        {
            ProductGroupDB.SaveAllProductGroups(CreateProductGroups());
        }
        path = JSONStorage.GetPath(Path.Combine(FolderNames.objects, "sagas.json"));
        if (!File.Exists(path)) File.Create(path);
        path = JSONStorage.GetPath(Path.Combine(FolderNames.objects, "cart.json"));
        if (!File.Exists(path)) File.Create(path);
    }
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private List<ProductGroup> CreateProductGroups()
    {
        List<ProductGroup> products = new List<ProductGroup>();
        products.Add(new ProductGroup(1, "Sticker", 1f));
        products.Add(new ProductGroup(2, "A5", 5f));
        products.Add(new ProductGroup(3, "A4", 7f));
        products.Add(new ProductGroup(4, "Pop Socket", 7f));
        products.Add(new ProductGroup(5, "Small Charm", 4f));
        products.Add(new ProductGroup(6, "Big Charm", 7f));
        products.Add(new ProductGroup(7, "Stock Sticker", .5f));
        return products;
    }

}
