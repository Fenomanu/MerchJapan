using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GenericImageLoading : MonoBehaviour
{
    // Kind of screen
    [SerializeField]
    private KINDS kind;


    // Erase
    [SerializeField]
    private Sprite placeholder;

    // Content to store sagas
    [SerializeField]
    private Transform content;

    [SerializeField]
    private Image imagePrefab; // Product Button To Instantiate
    [SerializeField]
    private TMP_Text groupMarkPrefab; // Product Group Divider Prefab To Instantiate
    [SerializeField]
    private DropDown sagaDropdownPrefab; // Product Saga Dropdown Prefab To Instantiate
    [SerializeField]
    private OpenDropAnim productViewPrefab; // Product Saga View Prefab To Instantiate

    [SerializeField]
    private ScrollRect scroll; // Scroll of products

    List<Product> products; // List of products loaded of the page kind
    Dictionary<int, ProductSaga> pSagas; // Sagas indexed by id
    Dictionary<int, ProductGroup> pGroups; // Groups names indexed by id
    Dictionary<int, Product> indexedProducts = new Dictionary<int, Product>(); // Products loaded indexed by id


    // Singleton Instance
    public static GenericImageLoading Instance { get; private set; }
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

    // Start is called before the first frame update
    void Start()
    {
        pSagas = ProductSagaDB.LoadFullProductSagasDictionary(); // Load groups
        pGroups = ProductGroupDB.LoadFullProductGroupsDictionary(); // Load sagas
        products = ProductDB.LoadKindproductOrdered(kind); // Load products
        if (products.Count == 0) return;
        // Dict key = saga, value = List<Product> from saga
        Dictionary<int, List<Product>> readyForButton = new Dictionary<int, List<Product>>();
        int i = products[0].productGroup.id;
        LoadGroupPrefab(i); // Load first divider
        int pointer = 0;
        foreach (Product p in products)
        {
            if (p.productGroup.id == i)
            {
                if (!readyForButton.ContainsKey(p.productSaga.id))
                {
                    readyForButton.Add(p.productSaga.id, new List<Product>());
                }
                readyForButton[p.productSaga.id].Add(p);
                if(pointer == products.Count-1)
                {
                    //StartCoroutine(LoadSagasWithProducts(readyForButton));
                    LoadSagasWithProducts(readyForButton);
                }
            }
            else
            {
                //StartCoroutine(LoadSagasWithProducts(readyForButton));
                LoadSagasWithProducts(readyForButton);
                readyForButton = new Dictionary<int, List<Product>>();
                if (!readyForButton.ContainsKey(p.productSaga.id))
                {
                    readyForButton.Add(p.productSaga.id, new List<Product>());
                }
                readyForButton[p.productSaga.id].Add(p);
                i = p.productGroup.id;
                LoadGroupPrefab(i);
                if (pointer == products.Count - 1)
                {
                    //StartCoroutine(LoadSagasWithProducts(readyForButton));
                    LoadSagasWithProducts(readyForButton);
                }
            }
            pointer++;
        }
        scroll.normalizedPosition = new Vector2(0, 1);
    }

    private void LoadGroupPrefab(int groupID)
    {
        //Instanciar prefab de grupo y setear propiedades (prefab TM_Text y modificar .text)
        Instantiate(groupMarkPrefab, content).text = pGroups[groupID].name;
    }

    private void LoadSagasWithProducts(Dictionary<int, List<Product>> productsBySaga)
    {
        DropDown sagaT;
        OpenDropAnim o;
        Image i;
        foreach (int saga in productsBySaga.Keys)
        {
            // Create Saga button
            sagaT = Instantiate(sagaDropdownPrefab, content);
            o = Instantiate(productViewPrefab, content);
            o.SetChildren(productsBySaga[saga].Count);
            sagaT.SetDropDown(pSagas[saga].name, o);
            foreach (Product p in productsBySaga[saga])
            {
                // Instatiate Product in Saga Button (Assign id to name)
                indexedProducts.Add(p.id, p);
                i = Instantiate(imagePrefab, o.transform);
                StartCoroutine(Utilities.LoadImageThread(p.get_image_path, i));
                i.name = p.id.ToString();
                //yield return null;
            }
        }
    }


    // Get product by id and add name to its productGroup
    public Product GetProduct(int pID)
    {
        Product p = indexedProducts[pID];
        p.productGroup.name = pGroups[p.productGroup.id].name;
        return p;
    }
    // Get product by id and add name to its productGroup
    public float GetGroupPrice(int pID)
    {
        return pGroups[pID].price;
    }
}
