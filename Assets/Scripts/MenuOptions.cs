using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadSticker()
    {
        StoreTempCart();
        SceneManager.LoadScene(2);
    }
    public void LoadPrint()
    {
        StoreTempCart();
        SceneManager.LoadScene(3);
    }
    public void LoadPopSocket()
    {
        StoreTempCart();
        SceneManager.LoadScene(4);
    }
    public void LoadKeyChain()
    {
        StoreTempCart();
        SceneManager.LoadScene(5);
    }
    public void LoadList()
    {
        SceneManager.LoadScene(6);
    }
    public void LoadPrices()
    {
        SceneManager.LoadScene(7);
    }
    public void LoadAdd()
    {
        SceneManager.LoadScene(8);
    }
    public void LoadNewSaga()
    {
        SceneManager.LoadScene(9);
    }
    public void LoadNewProduct()
    {
        SceneManager.LoadScene(10);
    }

    private void StoreTempCart()
    {
        CartManager.Instance.SaveTempCart();
    }
}
