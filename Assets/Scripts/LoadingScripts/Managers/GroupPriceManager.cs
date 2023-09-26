using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GroupPriceManager : MonoBehaviour
{
    public int id;
    [SerializeField]
    private TMP_InputField input;
    [SerializeField]
    private TMP_Text label;

    public float get_price
    {
        get
        {
            return float.Parse(input.text);
        }
    }

    public void SetProductGroup(int iD, string text, float price)
    {
        id = iD;
        label.text = text;
        input.text = price.ToString();
    }
    public void Edited()
    {
        OnChanged();
        PricesLoading.Instance.Edit();
    }

    public void OnChanged()
    {
        float price;
        string res = input.text.Replace(",", ".");
        try
        {
            price = float.Parse(res, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            input.text = price.ToString();
        }
        catch (Exception)
        {
            input.text = 1.ToString();
        }
    }
}
