using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductsLoading : MonoBehaviour
{
    public static ProductsLoading Instance { get; private set; }

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


    [SerializeField]
    private Sprite[] sprite;

    [SerializeField]
    private TMP_Dropdown groupDropdown;
    [SerializeField]
    private TMP_Dropdown sagaDropdown;

    [SerializeField]
    private Transform content;
    [SerializeField]
    private ProductManager productPrefab;
    [SerializeField]
    private ScrollRect scroll;
    List<ProductManager> pms;

    List<Product> products;

    Dictionary<int, string> groupsList;
    Dictionary<int, string> sagasList;

    // Start is called before the first frame update
    void Start()
    {
        pms = new List<ProductManager>();
        sagasList = ProductSagaDB.LoadProductSagasDictionary();
        groupsList = ProductGroupDB.LoadProductGroupsDictionary();
        products = ProductDB.LoadAllProducts();
        foreach (Product p in products)
        {
            CreateProductButton(p);
        }
        groupDropdown.AddOptions(groupsList.Values.ToList<string>());
        sagaDropdown.AddOptions(sagasList.Values.ToList<string>());
        scroll.normalizedPosition = new Vector2(0, 1);
    }



    public void CreateProductButton(Product p)
    {
        int kind = 0;
        switch(p.productGroup.id)
        {
            case 1:
            case 7:
                kind = 0;
                break;
            case 2:
            case 3:
                kind = 1;
                break;
            case 4:
                kind = 2;
                break;
            case 5:
            case 6:
                kind = 3;
                break;
        }
        pms.Add(Instantiate(productPrefab, content));
        pms[pms.Count - 1].SetProduct(p.id, p.name, groupsList[p.productGroup.id], sagasList[p.productSaga.id], sprite[kind]);
    }


    public void SaveNewProduct(string name, string imagePath, int groupPointer, int sagaPointer)
    {
        // Create Saga, add to list and store list
        Product newProduct = ProductDB.StoreNewProduct(name, imagePath, groupsList.ElementAt(groupPointer), sagasList.ElementAt(sagaPointer),  products);
        // Create Saga button
        CreateProductButton(newProduct);
    }
    public bool EraseProduct(int id)
    {
        Product product = products.FirstOrDefault(i => i.id == id);
        if (ProductDB.EraseProduct(product, products))
        {
            return true;
        }
        Debug.Log("Cant Erase, products associated");
        return false;
    }
}
