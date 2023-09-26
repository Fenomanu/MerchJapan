using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HDividerManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text date;
    [SerializeField]
    private TMP_Text price;

    public void SetDivider(JsonDateTime dt, float price)
    {
        this.date.text = ((System.DateTime)dt).ToString();
        this.price.text = price.ToString();
    }
}
