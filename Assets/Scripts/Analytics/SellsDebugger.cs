using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SellsDebugger : MonoBehaviour
{
    List<Cart> cartList;
    // Start is called before the first frame update
    void Start()
    {
        cartList = CartDB.LoadCartRegister();
        CartDebugger();
    }

    private void CartDebugger()
    {
        Dictionary<int, int> prodAmmounts = new Dictionary<int, int>();
        cartList = cartList.OrderBy(c => c.time.value).ToList();
        foreach(Cart c in cartList)
        {
            foreach(CartItem item in c.items)
            {
                if (!prodAmmounts.ContainsKey(item.pid))
                {
                    prodAmmounts.Add(item.pid, item.amm);
                }
                else
                {
                    prodAmmounts[item.pid] += item.amm;
                }

            }
        }
        List<KeyValuePair<int, int>> pamms = prodAmmounts.ToList();
        pamms = pamms.OrderByDescending(x => x.Value).ToList();
        Dictionary<int, Product> prods = ProductDB.LoadAllProductsDictionary();
        foreach(KeyValuePair<int, int> p in pamms)
        {
            print(p.Key + " - " + p.Value);
            if (prods.ContainsKey(p.Key))
            {
                print(prods[p.Key].name + " - " + p.Value + " Units");
            }
            else
            {
                print(p.Key + " - " + p.Value + " Units");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
