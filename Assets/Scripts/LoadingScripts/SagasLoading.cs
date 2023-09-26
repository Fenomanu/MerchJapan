using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SagasLoading : MonoBehaviour
{
    public static SagasLoading Instance { get; private set; }

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
    private SagaManager sagaPrefab;
    [SerializeField]
    private ScrollRect scroll;
    List<SagaManager> sms;

    List<ProductSaga> sagas;

    // Start is called before the first frame update
    void Start()
    {
        sms = new List<SagaManager>();
        sagas = ProductSagaDB.LoadAllProductSagas();
        foreach (ProductSaga g in sagas)
        {
            CreateSagaButton(g);
        }
        scroll.normalizedPosition = new Vector2(0, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateSagaButton(ProductSaga g)
    {
        sms.Add(Instantiate(sagaPrefab, content));
        sms[sms.Count - 1].SetSaga(g.id, g.name);
    }

    public void SaveNewSaga(string name)
    {
        // Create Saga, add to list and store list
        ProductSaga newSaga = ProductSagaDB.StoreNewSaga(name, sagas);
        // Create Saga button
        CreateSagaButton(newSaga);
        //foreach (ProductSaga s in sagas)
        //{
        //    SagaManager sm = sms.FirstOrDefault(i => i.id == s.id);
        //    s.price = sm.get_price;
        //}

        //ProductGroupDB.SaveAllProductGroups(groups);
        //ToggleEdit();
    }
    public bool EraseSaga(int id)
    {
        ProductSaga saga = sagas.FirstOrDefault(i => i.id == id);
        if (ProductSagaDB.EraseSaga(saga, sagas))
        {
            return true;
        }
        Debug.Log("Cant Erase, products associated");
        return false;
    }
}
