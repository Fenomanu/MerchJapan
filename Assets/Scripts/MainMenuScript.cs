using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    private ScrollRect scroll;
    private void Start()
    {
        CartDB.ClearTempCart();
        scroll.normalizedPosition = new Vector2(0, 1);
    }
    public void LoadSticker()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadPrint()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadPopSocket()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadKeyChain()
    {
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
}
