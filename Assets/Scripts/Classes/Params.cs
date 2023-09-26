using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Params
{
    public int nextProdID;
    public int nextSagaID;
    public int nextCartID;
    public Params()
    {
        nextProdID = 0;
        nextSagaID = 0;
        nextCartID = 0;
    }
}
