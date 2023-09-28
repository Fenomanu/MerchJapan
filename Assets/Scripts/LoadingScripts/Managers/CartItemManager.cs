using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CartItemManager : MonoBehaviour
{
    public int id;
    //public string name;
    //public string imageName;

    [SerializeField]
    private Image prodImage;
    private string imageName;
    [SerializeField]
    private TMP_Text nameText;
    private string nameT;
    [SerializeField]
    private TMP_Text groupText;
    private string groupT;
    private int groupid;
    [SerializeField]
    private TMP_InputField ammountField;
    private int ammount;
    public bool loaded = false;
    // Start is called before the first frame update
    public CartItemManager SetLoadedProduct(Product p, int amm, Sprite sprite)
    {
        id = p.id;
        prodImage.sprite = sprite;
        loaded = true;
        imageName = p.get_image_path;
        nameText.text = p.name;
        nameT = p.name;
        groupText.text = p.productGroup.name;
        groupT = p.productGroup.name;
        groupid = p.productGroup.id;
        ammount = amm;
        ammountField.text = amm.ToString();
        return this;
    }
    public CartItemManager SetNewProduct(int iD, string name, int groupid, string group, int amm, string imageName)
    {
        id = iD;
        this.imageName = imageName;
        nameText.text = name;
        nameT = name;
        groupText.text = group;
        groupT = group;
        this.groupid = groupid;
        ammount = amm;
        ammountField.text = amm.ToString();
        print(ammountField.text);
        return this;
    }
    public void EraseProductButton()
    {
        if (CartManager.Instance.EraseItem(id, ammount, groupid))
        {
            Destroy(this.gameObject);
        }
    }
    public void AddOne()
    {
        ammount++;
        ammountField.text = ammount.ToString();
    }
    public int GetAmmount()
    {
        return ammount;
    }
    public CartTempItem GetTempItem()
    {
        print(nameText.name);
        return new CartTempItem(id, nameT, groupid, groupT, ammount, imageName);
    }
    public void LoadImage()
    {
        StartCoroutine(Utilities.LoadImageThread(JSONStorage.GetPath(imageName), prodImage));
        loaded = true;
    }

    public void OnChangedAmmount()
    {
        try
        {
            int newAmmount = int.Parse(ammountField.text);
            if (newAmmount > ammount)
            {
                CartManager.Instance.AddAmmount(newAmmount - ammount, groupid);
            }
            if (newAmmount < ammount)
            {
                CartManager.Instance.SubAmmount(ammount - newAmmount, groupid);
            }
            ammount = newAmmount;
            if(ammount == 0)
            {
                EraseProductButton();
            }
        }
        catch (Exception)
        {
            if (1 > ammount)
            {
                CartManager.Instance.SubAmmount(ammount - 1, groupid);
            }
            if (ammount < 1)
            {
                CartManager.Instance.AddAmmount(1 - ammount, groupid);
            }
            ammountField.text = 1.ToString();
            ammount = 1;
        }
    }
}
