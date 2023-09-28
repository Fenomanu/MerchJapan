using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CartManager : MonoBehaviour
{
    // Cart Modal
    [SerializeField]
    private Canvas modal;
    // Content to spawn cart items
    [SerializeField]
    private Transform content;
    // Cart Items prefab
    [SerializeField]
    private CartItemManager cartItemPrefab;
    [SerializeField]
    private ScrollRect scroll; // Scroll of items
    [SerializeField]
    private TMP_InputField priceField;
    private float price = 0f;
    [SerializeField]
    private Animator cartAdder;

    // Dictionary of cartItemPrefabs managers indexed by product ID
    Dictionary<int, CartItemManager> prodAmmount = new Dictionary<int, CartItemManager>();



    public static CartManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        priceField.text = price.ToString();
        CartTemp cart = CartDB.LoadTempCart();
        if(cart != null && cart.items != null && cart.items.Count > 0)
        {
            cartAdder.SetTrigger("Add");
            foreach (CartTempItem c in cart.items)
            {
                AddPrefabNew(c.id, c.name, c.groupid, c.group, c.amm, c.imagePath);
            }
            priceField.text = cart.price.ToString();
            price = cart.price;

            scroll.normalizedPosition = new Vector2(0, 1);
        }
    }

    public void ShowModal()
    {
        modal.enabled = true;
        modal.GetComponent<Animator>().SetTrigger("Show");
        foreach(CartItemManager c in prodAmmount.Values)
        {
            if (!c.loaded) c.LoadImage();
        }
    }
    public void HideModal()
    {
        modal.enabled = false;
    }
    public void LoadCart()
    {

    }

    public void SaveTempCart()
    {
        // Create Saga, add to list and store list
        List<CartTempItem> items = new List<CartTempItem>();
        foreach (CartItemManager cartItem in prodAmmount.Values)
        {
            print(cartItem.name);
            items.Add(cartItem.GetTempItem());
        }
        CartTemp c = new CartTemp(float.Parse(priceField.text), items);
        CartDB.SaveTempCart(c);
        this.StopAllCoroutines();
    }

    public void SaveCart(Button b)
    {
        // Create Saga, add to list and store list
        List<CartItem> items = new List<CartItem>();
        foreach(CartItemManager cartItem in prodAmmount.Values)
        {
            items.Add(new CartItem(cartItem.id, cartItem.GetAmmount()));
        }
        Cart c = new Cart(float.Parse(priceField.text), items, (JsonDateTime)System.DateTime.Now);
        CartDB.StoreCartRegister(c);
        b.enabled = false;
        ClearCart();
        b.enabled = true;
        HideModal();
    }

    private void ClearCart()
    {
        foreach (CartItemManager cartIt in prodAmmount.Values)
        {
            Destroy(cartIt.gameObject);
        }
        prodAmmount = new Dictionary<int, CartItemManager>();
        CartDB.ClearTempCart();
        SetPrice(0);
        cartAdder.Play("Hidden");
    }

    public void AddProductToCart(int pid, Sprite sprite)
    {
        Product product = GenericImageLoading.Instance.GetProduct(pid);
        if (!prodAmmount.ContainsKey(pid))
        {
            AddPrefabLoaded(product, 1, sprite);
        }
        else
        {
            prodAmmount[pid].AddOne();
        }
        SetPrice(price + GenericImageLoading.Instance.GetGroupPrice(product.productGroup.id));
        cartAdder.SetTrigger("Add");
    }

    public void SetPrice(float p)
    {
        price = p;
        priceField.text = p.ToString();
    }

    public void AddAmmount(int a, int gid)
    {
        price += a*GenericImageLoading.Instance.GetGroupPrice(gid);
        priceField.text = price.ToString();
    }
    public void SubAmmount(int a, int gid)
    {
        price -= a * GenericImageLoading.Instance.GetGroupPrice(gid);
        if (price < 0) price = 0;
        priceField.text = price.ToString();
    }

    public bool EraseItem(int id, int ammount, int gid)
    {
        SubAmmount(ammount, gid);
        prodAmmount.Remove(id);
        if(prodAmmount.Count == 0)
        {
            cartAdder.Play("Hidden");
        }
        return true;
    }

    // Add Prefab for loaded item
    public void AddPrefabLoaded(Product p, int amm, Sprite sprite)
    {
        prodAmmount.Add(p.id, Instantiate(cartItemPrefab, content).SetLoadedProduct(p, amm, sprite));
    }
    // Add prefab for new Item
    public void AddPrefabNew(int iD, string name, int groupid, string group, int amm, string imagePath)
    {
        prodAmmount.Add(iD, Instantiate(cartItemPrefab, content).SetNewProduct(iD, name, groupid, group, amm, imagePath));
    }

    public void OnChanged()
    {
        string res = priceField.text.Replace(",", ".");
        try
        {
            price = float.Parse(res, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            priceField.text = price.ToString();
        }
        catch (Exception)
        {
            priceField.text = price.ToString();
        }
    }
}
