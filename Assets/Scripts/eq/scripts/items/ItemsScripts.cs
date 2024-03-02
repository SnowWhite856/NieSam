using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item1Script : MonoBehaviour
{
    private void OnMouseDown()
    {
        FindFirstObjectByType<playerEq>().addItems();
        FindFirstObjectByType<playerEq>().deleteUI();

        var limit = FindFirstObjectByType<playerEq>().allItems;
        if (limit > 14)
        {
            FindFirstObjectByType<playerEq>().showInfo();
            return;
        }

        FindFirstObjectByType<EqScipt>().item.Add(gameObject.GetComponent<itemsClass>());
        gameObject.SetActive(false);
    }
}
