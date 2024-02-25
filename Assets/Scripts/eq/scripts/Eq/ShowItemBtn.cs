using System.Collections;
using System.Collections.Generic;
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
       var item = FindObjectOfType<EqScipt>().item;

         foreach(var findItem in item)
         {
            if (findItem.name == gameObject.name)
            {
                try
                {
                    itemRarity.text = findItem.GetComponent<WaponsClass>().rarity;
                }
                catch {}
                    itemDescription.text = findItem.GetComponent<itemsClass>().Description;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnButtonClick();
        }
    }

    private void Awake()
    {
        myButton = FindObjectOfType<Button>();
        myButton.onClick.AddListener(OnButtonClick);
    }
}
