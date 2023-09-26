using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Product
{
    public int id;
    public string name;
    public string imageName;
    public ProductGroup productGroup;
    public ProductSaga productSaga;
    public Product() { }
    public Product(string name, string originalImagePath, int groupID, int sagaID)
    {
        this.id = ParamsBD.GetAndIncrementNextProductID();
        this.name = name;
        this.imageName = id.ToString() + Path.GetExtension(originalImagePath);
        this.productGroup = new ProductGroup(groupID);
        this.productSaga = new ProductSaga(sagaID);
    }
    public Product(int iD)
    {
        id = iD;
    }
    public string get_image_path
    {
        get
        {
            return Path.Combine(productSaga.get_folder_path, imageName);
        }
    }
}
