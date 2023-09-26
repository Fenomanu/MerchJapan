using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ParamsBD
{
    public static Params LoadParams()
    {
        return JSONStorage.ReadFromJSONObj<Params>(Path.Combine(FolderNames.objects, "params.json"));
    }

    public static void SaveParams(Params pars)
    {
        JSONStorage.SaveToJSONObj<Params>(pars, Path.Combine(FolderNames.objects, "params.json"));
    }

    public static int GetAndIncrementNextSagaID()
    {
        Params p = LoadParams();
        int thisId = p.nextSagaID;
        p.nextSagaID++;
        SaveParams(p);
        return thisId;
    }

    public static int GetAndIncrementNextProductID()
    {
        Params p = LoadParams();
        int thisId = p.nextProdID;
        p.nextProdID++;
        SaveParams(p);
        return thisId;
    }

    public static int GetAndIncrementNextCartID()
    {
        Params p = LoadParams();
        int thisId = p.nextCartID;
        p.nextCartID++;
        SaveParams(p);
        return thisId;
    }
}
