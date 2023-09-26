using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDropAnim : MonoBehaviour
{
    [SerializeField]
    private float openTime = .15f;
    [SerializeField]
    private GridLayoutGroup grid;
    [SerializeField]
    private RectTransform _transform;
    private bool open = false;
    private bool isOpen;
    //private bool animating;
    private int nRows;
    private float yObj;
    private float openSpeed;
    public int children;

    public void SetChildren(int ch) 
    {
        children = ch;
    }

    private void Start()
    {
        _transform = GetComponent<RectTransform>();
        grid = GetComponent<GridLayoutGroup>();
        nRows = (int)(children/grid.constraintCount);
        if (children % grid.constraintCount > 0) nRows++; 
        yObj = grid.padding.top + grid.padding.bottom + (nRows * (grid.cellSize.y + grid.spacing.y));
        openSpeed = (yObj / openTime);
        //print(yObj);
    }
    public void ToggleView()
    {
        open = !open;
    }
    // Update is called once per frame
    void Update()
    {
        if(!isOpen&&open)
        {
            _transform.sizeDelta += openSpeed*Time.deltaTime*Vector2.up;
            if(_transform.sizeDelta.y >= yObj)
            {
                _transform.sizeDelta = new Vector2(1080, yObj);
                isOpen = true;
            }
        }
        else if(isOpen && !open)
        {
            _transform.sizeDelta -= openSpeed * Time.deltaTime * Vector2.up;
            if (_transform.sizeDelta.y <= 0)
            {
                _transform.sizeDelta = new Vector2(1080,0);
                isOpen = false;
            }
        }
    }
}
