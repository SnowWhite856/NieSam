using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.FilePathAttribute;

public class EqScipt : MonoBehaviour
{
    public List<GameObject> item = new List<GameObject>();
    public GameObject currentWapon = null;
    public GameObject currentWapon2 = null;
    public GameObject currentHelmet = null;
    public GameObject currentPlate = null;
    public GameObject currentBoots = null;

    public UnityEvent onValueChanged;

    public void addToEq(GameObject newObject)
    {
        item.Add( newObject );

        GetComponent<playerEq>().addItems();
        GetComponent<playerEq>().deleteUI();
    }

    //public Transform waponSlot;
    public void setWapon()
    {
        GameObject waponSlot = GameObject.Find("WaponSlot");

        var wapon1 = currentWapon.name;
        var itemPath = "Prefabs/"+ wapon1;
        GameObject prefab = Resources.Load<GameObject>(itemPath);
    }
}
