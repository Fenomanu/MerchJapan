using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class ProductSaga
{
    public int id;
    public string name;
    public string folderName;
    public string get_folder_path
    {
        get 
        {
            return JSONStorage.GetPath(Path.Combine(FolderNames.images, id.ToString()));
        }
    }

    public ProductSaga()
    {
        id = 0;
        name = "";
        folderName = "";
    }
    public ProductSaga(int id, string name, string folderName)
    {
        this.id = id;
        this.name = name;
        this.folderName = folderName;
    }
    public ProductSaga(int id)
    {
        this.id = id;
        this.folderName = id.ToString();
    }
    public ProductSaga(string name)
    {
        this.id = ParamsBD.GetAndIncrementNextSagaID();
        this.name = name;
        this.folderName = id.ToString();
    }
}
