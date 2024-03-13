using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombineBtnScript : MonoBehaviour
{
    public Button myButton;
    public TextMeshProUGUI myText;
    public itemsClass[] toCombine = new itemsClass[2];

    private itemsClass temp;
    public void Combine()
    {
        var item = FindFirstObjectByType<EqScipt>().item;

        if (toCombine[1] != null) return;
        foreach (var findItem in item)
        {
            if (findItem.GetComponent<itemsClass>().Description == myText.text)
            {
                temp = findItem;
                break;
            }
        }

        if (toCombine[0] == null)
        {
            toCombine[0] = temp;
        }
        else
        {
            toCombine[1] = temp;
        }

        FindFirstObjectByType<EqScipt>().item.Remove(temp);
        FindFirstObjectByType<playerEq>().deleteUI();
        FindFirstObjectByType<playerEq>().addItems();
        myText.text = "";
        FindFirstObjectByType<ShowItemBtn>().itemRarity.text = "";
        temp = null;
    }

    private void Awake()
    {
        myButton.onClick.AddListener(Combine);
    }
}
