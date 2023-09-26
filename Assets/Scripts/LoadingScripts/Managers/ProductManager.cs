using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductManager : MonoBehaviour
{
    public int id;
    [SerializeField]
    private Image kindImage;
    [SerializeField]
    private TMP_Text nameText;
    [SerializeField]
    private TMP_Text groupText;
    [SerializeField]
    private TMP_Text sagaText;

    public void SetProduct(int iD, string name, string group, string saga, Sprite sprite)
    {
        id = iD;
        kindImage.sprite = sprite;
        nameText.text = name;
        groupText.text = group;
        sagaText.text = saga;
    }
    public void EraseProductButton()
    {
        if (ProductsLoading.Instance.EraseProduct(id))
        {
            Destroy(this.gameObject);
        }
    }
}
