using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EquipBtnScript : MonoBehaviour
{
    public Button myButton;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI WaponSlot;
    public TextMeshProUGUI WaponSlot2;
    public TextMeshProUGUI HelmetSlot;
    public TextMeshProUGUI PlateSlot;
    public TextMeshProUGUI BootsSlot;


    private GameObject toEquip;

    public void EquipItemClick()
    {
        var item = FindObjectOfType<EqScipt>().item;
        foreach (var findItem in item)
        {
            if (findItem.GetComponent<itemsClass>().Description == itemDescription.text)
            {
                toEquip = findItem;
                break;
            }
        }


        switch (toEquip.tag)
        {
            case "wapon":
                if (WaponSlot.text != "")
                {
                    var pastWapon = FindObjectOfType<EqScipt>().currentWapon;
                    FindObjectOfType<EqScipt>().item.Add(pastWapon);
                    FindObjectOfType<PlayerStats>().TakeOffItem(pastWapon, "wapon");
                }
                FindObjectOfType<EqScipt>().currentWapon = toEquip;
                FindObjectOfType<EqScipt>().item.Remove(toEquip);
                WaponSlot.text = toEquip.GetComponent<itemsClass>().name;
                FindObjectOfType<PlayerStats>().TakeOnItem(toEquip,"wapon");
                break;

            case "wapon2":
                if (WaponSlot2.text != "")
                {
                    var pastWapon = FindObjectOfType<EqScipt>().currentWapon2;
                    FindObjectOfType<EqScipt>().item.Add(pastWapon);
                    FindObjectOfType<PlayerStats>().TakeOffItem(pastWapon, "wapon");
                }
                FindObjectOfType<EqScipt>().currentWapon2 = toEquip;
                FindObjectOfType<EqScipt>().item.Remove(toEquip);
                WaponSlot2.text = toEquip.GetComponent<itemsClass>().name;
                FindObjectOfType<PlayerStats>().TakeOnItem(toEquip, "wapon");
                break;

            case "helmet":
                if (HelmetSlot.text != "")
                {
                    var pastHelmet = FindObjectOfType<EqScipt>().currentHelmet;
                    FindObjectOfType<EqScipt>().item.Add(pastHelmet);
                    FindObjectOfType<PlayerStats>().TakeOffItem(pastHelmet, "armor");
                }
                FindObjectOfType<EqScipt>().currentHelmet = toEquip;
                FindObjectOfType<EqScipt>().item.Remove(toEquip);
                HelmetSlot.text = toEquip.GetComponent<itemsClass>().name;
                FindObjectOfType<PlayerStats>().TakeOnItem(toEquip, "armor");
                break;

            case "plate":
                if (PlateSlot.text != "")
                {
                    var pastPlate = FindObjectOfType<EqScipt>().currentPlate;
                    FindObjectOfType<EqScipt>().item.Add(pastPlate);
                    FindObjectOfType<PlayerStats>().TakeOffItem(pastPlate, "armor");
                }
                FindObjectOfType<EqScipt>().currentPlate = toEquip;
                FindObjectOfType<EqScipt>().item.Remove(toEquip);
                PlateSlot.text = toEquip.GetComponent<itemsClass>().name;
                FindObjectOfType<PlayerStats>().TakeOnItem(toEquip, "armor");
                break;

            case "boots":
                if (BootsSlot.text != "")
                {
                    var pastBoots = FindObjectOfType<EqScipt>().currentBoots;
                    FindObjectOfType<EqScipt>().item.Add(pastBoots);
                    FindObjectOfType<PlayerStats>().TakeOffItem(pastBoots, "armor");
                }
                FindObjectOfType<EqScipt>().currentBoots = toEquip;
                FindObjectOfType<EqScipt>().item.Remove(toEquip);
                BootsSlot.text = toEquip.GetComponent<itemsClass>().name;
                FindObjectOfType<PlayerStats>().TakeOnItem(toEquip, "armor");
                break;
        }

        FindObjectOfType<playerEq>().deleteUI();
        FindObjectOfType<playerEq>().addItems();
        itemDescription.text = "";
        FindObjectOfType<ShowItemBtn>().itemRarity.text = "";
        toEquip = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EquipItemClick();
        }
    }

    private void Awake()
    {
        myButton.onClick.AddListener(EquipItemClick);
    }
}
