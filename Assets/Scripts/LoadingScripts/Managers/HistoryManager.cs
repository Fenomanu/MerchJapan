using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HistoryManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text pName;
    [SerializeField]
    private TMP_Text pGroup;
    [SerializeField]
    private TMP_Text ammount;
    public void SetItem(string pName, string pGroup, int ammount)
    {
        this.pName.text = pName;
        this.pGroup.text = pGroup;
        this.ammount.text = ammount.ToString();
    }
}
