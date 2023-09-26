using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SagaManager : MonoBehaviour
{
    public int id;
    [SerializeField]
    private TMP_Text text;

    public void SetSaga(int iD, string text)
    {
        id = iD;
        this.text.text = text;
    }
    public void EraseSagaButton()
    {
        if(SagasLoading.Instance.EraseSaga(id))
        {
            Destroy(this.gameObject);
        }
    }
}
