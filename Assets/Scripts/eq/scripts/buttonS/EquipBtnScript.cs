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


    private itemsClass toEquip;

    public void EquipItemClick()
    {
        var item = FindFirstObjectByType<EqScipt>().item;
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
                    var pastWapon = FindFirstObjectByType<EqScipt>().currentWapon;
                    FindFirstObjectByType<EqScipt>().item.Add(pastWapon);
                    FindFirstObjectByType<PlayerStats>().TakeOffItem(pastWapon, "wapon");
                }
                FindFirstObjectByType<EqScipt>().currentWapon = (WaponsClass)toEquip;
                FindFirstObjectByType<EqScipt>().item.Remove(toEquip);
                WaponSlot.text = toEquip.GetComponent<itemsClass>().name;
                FindFirstObjectByType<PlayerStats>().TakeOnItem(toEquip,"wapon");
                FindFirstObjectByType<EqScipt>().setWapon();
                break;

            case "wapon2":
                if (WaponSlot2.text != "")
                {
                    var pastWapon = FindFirstObjectByType<EqScipt>().currentWapon2;
                    FindFirstObjectByType<EqScipt>().item.Add(pastWapon);
                    FindFirstObjectByType<PlayerStats>().TakeOffItem(pastWapon, "wapon");
                }
                FindFirstObjectByType<EqScipt>().currentWapon2 = (WaponsClass)toEquip;
                FindFirstObjectByType<EqScipt>().item.Remove(toEquip);
                WaponSlot2.text = toEquip.GetComponent<itemsClass>().name;
                FindFirstObjectByType<PlayerStats>().TakeOnItem(toEquip, "wapon");
                FindFirstObjectByType<EqScipt>().setWapon2();
                break;

            case "helmet":
                if (HelmetSlot.text != "")
                {
                    var pastHelmet = FindFirstObjectByType<EqScipt>().currentHelmet;
                    FindFirstObjectByType<EqScipt>().item.Add(pastHelmet);
                    FindFirstObjectByType<PlayerStats>().TakeOffItem(pastHelmet, "armor");
                }
                FindFirstObjectByType<EqScipt>().currentHelmet = (ArmourClass)toEquip;
                FindFirstObjectByType<EqScipt>().item.Remove(toEquip);
                HelmetSlot.text = toEquip.GetComponent<itemsClass>().name;
                FindFirstObjectByType<PlayerStats>().TakeOnItem(toEquip, "armor");
                break;

            case "plate":
                if (PlateSlot.text != "")
                {
                    var pastPlate = FindFirstObjectByType<EqScipt>().currentPlate;
                    FindFirstObjectByType<EqScipt>().item.Add(pastPlate);
                    FindFirstObjectByType<PlayerStats>().TakeOffItem(pastPlate, "armor");
                }
                FindFirstObjectByType<EqScipt>().currentPlate = (ArmourClass)toEquip;
                FindFirstObjectByType<EqScipt>().item.Remove(toEquip);
                PlateSlot.text = toEquip.GetComponent<itemsClass>().name;
                FindFirstObjectByType<PlayerStats>().TakeOnItem(toEquip, "armor");
                break;

            case "boots":
                if (BootsSlot.text != "")
                {
                    var pastBoots = FindFirstObjectByType<EqScipt>().currentBoots;
                    FindFirstObjectByType<EqScipt>().item.Add(pastBoots);
                    FindFirstObjectByType<PlayerStats>().TakeOffItem(pastBoots, "armor");
                }
                FindFirstObjectByType<EqScipt>().currentBoots = (ArmourClass)toEquip;
                FindFirstObjectByType<EqScipt>().item.Remove(toEquip);
                BootsSlot.text = toEquip.GetComponent<itemsClass>().name;
                FindFirstObjectByType<PlayerStats>().TakeOnItem(toEquip, "armor");
                break;
        }

        FindFirstObjectByType<playerEq>().deleteUI();
        FindFirstObjectByType<playerEq>().addItems();
        itemDescription.text = "";
        FindFirstObjectByType<ShowItemBtn>().itemRarity.text = "";
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
