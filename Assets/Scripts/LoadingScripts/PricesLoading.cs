using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PricesLoading : MonoBehaviour
{
    public static PricesLoading Instance { get; private set; }

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
    private Transform content;
    [SerializeField]
    private GroupPriceManager pricePrefab;
    [SerializeField]
    private ScrollRect scroll;
    List<GroupPriceManager> gpm;

    private bool edited;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private Image image;

    List<ProductGroup> groups;

    // Start is called before the first frame update
    void Start()
    {
        gpm = new List<GroupPriceManager>();
        groups = ProductGroupDB.LoadAllProductGroups();
        foreach(ProductGroup g in groups)
        {
            gpm.Add(Instantiate(pricePrefab, content));
            gpm[gpm.Count-1].SetProductGroup(g.id, g.name, g.price);
        }
        scroll.normalizedPosition = new Vector2(0, 1);
        if(edited) ToggleEdit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Edit()
    {
        if(!edited)
        {
            ToggleEdit();
        }
    }
    private void ToggleEdit()
    {
        if(edited)
        {
            edited = false;
            image.sprite = sprites[0];
        }
        else
        {
            edited = true;
            image.sprite = sprites[1];
        }
    }

    public void SavePrices()
    {
        foreach(ProductGroup g in groups)
        {
            GroupPriceManager gp = gpm.FirstOrDefault(i => i.id == g.id);
            g.price = gp.get_price;
        }

        ProductGroupDB.SaveAllProductGroups(groups);
        ToggleEdit();
    }
}
