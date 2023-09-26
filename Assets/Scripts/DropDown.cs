using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDown : MonoBehaviour
{
    [SerializeField]
    private OpenDropAnim dropView;
    [SerializeField]
    private TMP_Text nameLabel;
    public void SetDropDown(string name, OpenDropAnim drop)
    {
        nameLabel.text = name;
        dropView = drop;
    }
    public void ToggleView()
    {
        dropView.ToggleView();
    }
}
