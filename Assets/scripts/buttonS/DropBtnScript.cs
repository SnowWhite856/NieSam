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
    public int toDelete;

    public void DropItemClick()
    {
        var item = FindFirstObjectByType<EqScipt>().item;
        item.RemoveAt(toDelete);

        FindFirstObjectByType<playerEq>().deleteUI();
        FindFirstObjectByType<playerEq>().addItems();
        myText.text = "";
        FindFirstObjectByType<ShowItemBtn>().itemRarity.text = "";
    }

    private void Awake()
    {
        myButton.onClick.AddListener(DropItemClick);
    }
}