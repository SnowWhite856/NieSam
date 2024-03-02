using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DropBtnScript : MonoBehaviour
{
    public Button myButton;
    public TextMeshProUGUI myText;
    private itemsClass toDelete;

    public void DropItemClick()
    {
        var item = FindFirstObjectByType<EqScipt>().item;
        foreach (var findItem in item)
        {
            toDelete = findItem;
        }
        FindFirstObjectByType<EqScipt>().item.Remove(toDelete);
        FindFirstObjectByType<playerEq>().deleteUI();
        FindFirstObjectByType<playerEq>().addItems();
        myText.text = "";
        FindFirstObjectByType<ShowItemBtn>().itemRarity.text = "";

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropItemClick();
        }
    }

    private void Awake()
    {
        myButton.onClick.AddListener(DropItemClick);
    }
}