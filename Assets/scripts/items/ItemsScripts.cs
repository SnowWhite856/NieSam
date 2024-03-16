using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item1Script : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

        FindFirstObjectByType<playerEq>().addItems();
        FindFirstObjectByType<playerEq>().deleteUI();

        var limit = FindFirstObjectByType<playerEq>().allItems;
        if (limit > 14)
        {
            FindFirstObjectByType<playerEq>().showInfo();
            return;
        }
        Debug.Log("add");
        FindFirstObjectByType<EqScipt>().item.Add(gameObject.GetComponent<itemsClass>());
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.SetActive(false);
        }
    }

}
