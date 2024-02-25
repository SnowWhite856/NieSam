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
    private GameObject toDelete;

    public void DropItemClick()
    {
        var item = FindObjectOfType<EqScipt>().item;
        foreach (var findItem in item)
        {
            toDelete = findItem;
        }
        FindObjectOfType<EqScipt>().item.Remove(toDelete);
        FindObjectOfType<playerEq>().deleteUI();
        FindObjectOfType<playerEq>().addItems();
        myText.text = "";
        FindObjectOfType<ShowItemBtn>().itemRarity.text = "";

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