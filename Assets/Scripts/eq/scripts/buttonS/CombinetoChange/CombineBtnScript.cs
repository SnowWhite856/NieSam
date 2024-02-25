using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombineBtnScript : MonoBehaviour
{
    public Button myButton;
    public TextMeshProUGUI myText;
    public GameObject[] toCombine = new GameObject[2];

    private GameObject temp;
    public void Combine()
    {
        var item = FindObjectOfType<EqScipt>().item;

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

        FindObjectOfType<EqScipt>().item.Remove(temp);
        FindObjectOfType<playerEq>().deleteUI();
        FindObjectOfType<playerEq>().addItems();
        myText.text = "";
        FindObjectOfType<ShowItemBtn>().itemRarity.text = "";
        temp = null;
    }

    private void Awake()
    {
        myButton.onClick.AddListener(Combine);
    }
}
