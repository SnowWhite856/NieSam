using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.FilePathAttribute;

public class EqScipt : MonoBehaviour
{
    //public List<GameObject> item = new List<GameObject>();
    public List<itemsClass> item = new List<itemsClass>();

    public WaponsClass currentWapon;
    public WaponsClass currentWapon2 = null;

    public ArmourClass currentHelmet = null;
    public ArmourClass currentPlate = null;
    public ArmourClass currentBoots = null;

    public UnityEvent onValueChanged;

    private int currentId;
    public enum allMainWapon
    {
        Spear,
        Sword
    }

    public void addToEq(itemsClass newObject)
    {
        //item.Add( newObject );

        /*
        //nadawanie przedmiotom id
        currentId = 1;
        foreach ( var item in item)
        {
            item.GetComponent<itemsClass>().Id = currentId;
            currentId++;
        }
        */
        GetComponent<playerEq>().addItems();
        GetComponent<playerEq>().deleteUI();
    }

    //public Transform waponSlot;
    public void setWapon()
    {
        GameObject waponSlot = GameObject.Find("WaponSlot");
        try
        {
            Transform child = waponSlot.transform.GetChild(0);
            Destroy(child.gameObject);
        }
        catch { }

        var wapon1 = currentWapon.name;
        var itemPath = "Prefabs/"+ wapon1;
        
        GameObject prefab = Resources.Load<GameObject>(itemPath);

        var waponInEq = Instantiate(prefab, waponSlot.transform);
        waponInEq.AddComponent<Rigidbody>();
        waponInEq.GetComponent<Item1Script>().enabled = false;
        waponInEq.name = wapon1;
    }

    public void setWapon2()
    {
        GameObject waponSlot2 = GameObject.Find("Wapon2Slot");
        try
        {
            Transform child = waponSlot2.transform.GetChild(0);
            Destroy(child.gameObject);
        }
        catch { }
        var wapon2 = currentWapon2.name;
        var itemPath2 = "Prefabs/" + wapon2;

        GameObject prefab2 = Resources.Load<GameObject>(itemPath2);

        var waponInEq2 = Instantiate(prefab2, waponSlot2.transform);
        waponInEq2.name = wapon2;
    }

    }
