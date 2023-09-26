using UnityEngine;
using UnityEngine.UI;

public class ImageButton : MonoBehaviour
{
    public void Select()
    {
        print("Selected");
        CartManager.Instance.AddProductToCart(int.Parse(this.name), this.GetComponent<Image>().sprite);
    }
}
