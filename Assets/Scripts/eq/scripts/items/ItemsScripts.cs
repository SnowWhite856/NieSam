using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item1Script : MonoBehaviour
{
    private void OnMouseDown()
    {
        FindObjectOfType<playerEq>().addItems();
        FindObjectOfType<playerEq>().deleteUI();

        var limit = FindObjectOfType<playerEq>().allItems;
        if (limit > 14)
        {
            FindObjectOfType<playerEq>().showInfo();
            return;
        }

        Vector3 pozycja = new Vector3(0, -20, 0);
        FindObjectOfType<EqScipt>().item.Add(gameObject);
        //Destroy(gameObject);
        gameObject.transform.position = pozycja;
    }
}
