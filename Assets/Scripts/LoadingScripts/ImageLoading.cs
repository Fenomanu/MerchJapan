using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoading : MonoBehaviour
{

    [SerializeField]
    private RectTransform imagePrefab;

    [SerializeField]
    private string[] pokeImagePaths;
    [SerializeField]
    private string[] mhImagePaths;
    [SerializeField]
    private string[] lolImagePaths;

    [SerializeField]
    private Transform pokeView;
    [SerializeField]
    private Transform mhView;
    [SerializeField]
    private Transform lolView;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform image;
        foreach(string path in pokeImagePaths)
        {
            image = Instantiate(imagePrefab, pokeView);
            image.GetComponent<Image>().sprite = Utilities.LoadImage(Application.persistentDataPath + path);
        }
        foreach(string path in mhImagePaths)
        {

        }
        foreach(string path in lolImagePaths)
        {

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
