using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryLoading : MonoBehaviour
{

    [SerializeField]
    private Transform content;
    [SerializeField]
    private HistoryManager historyPrefab;
    [SerializeField]
    private HDividerManager hDividerPrefab;
    [SerializeField]
    private ScrollRect scroll;
    List<Cart> carts;
    Dictionary<int,Product> products;
    //Dictionary<int,ProductSaga> sagas;
    Dictionary<int,ProductGroup> groups;
    private void Start()
    {
        carts = CartDB.LoadCartRegister();
        products = ProductDB.LoadAllProductsDictionary();
        //sagas = ProductSagaDB.LoadFullProductSagasDictionary();
        groups = ProductGroupDB.LoadFullProductGroupsDictionary();
        StartCoroutine(LoadAllRegisters());
    }

    private IEnumerator LoadAllRegisters()
    {
        Product p;
        foreach(Cart cart in carts)
        {
            foreach(CartItem ci in cart.items)
            {
                if (products.ContainsKey(ci.pid))
                {
                    p = products[ci.pid];
                    Instantiate(historyPrefab, content).SetItem(p.name, groups[p.productGroup.id].name, ci.amm);
                }
                else
                {
                    Instantiate(historyPrefab, content).SetItem("Unknown", "Unknown", ci.amm);
                    Debug.Log(string.Join(" ", "Product", ci.pid, "does not exist anymore"));
                }
            }
            Instantiate(hDividerPrefab, content).SetDivider(cart.time, cart.price);
        }
        yield return null;
    }
}
