using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowItemBtn : MonoBehaviour
{
    public Button myButton;

    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemRarity;
    public Image itemImage;

    public void OnButtonClick()
    {
        var item = FindFirstObjectByType<EqScipt>().item;
        try
        {
            itemRarity.text = gameObject.GetComponent<WaponsClass>().rarity;
        }
        catch { }
        itemDescription.text = gameObject.GetComponent<itemsClass>().Description;

        FindFirstObjectByType<DropBtnScript>().toDelete = gameObject.GetComponent<itemsClass>().Id;
    }

    private void Awake()
    {
        myButton = FindFirstObjectByType<Button>();
        myButton.onClick.AddListener(OnButtonClick);
    }
}
