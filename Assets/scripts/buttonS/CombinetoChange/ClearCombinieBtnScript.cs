using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearCombinieBtnScript : MonoBehaviour
{
    public Button myButton;
    public bool isBack;
    public void ClearCombine()
    {
        var item = FindFirstObjectByType<EqScipt>().item;

        for (int i = 0; i < 2; i++)
        {
            if(FindFirstObjectByType<CombineBtnScript>().toCombine[i] != null)
            {
                if (isBack)
                {
                    item.Add(FindFirstObjectByType<CombineBtnScript>().toCombine[i]);
                }
                FindFirstObjectByType<CombineBtnScript>().toCombine[i] = null;
            }
        }

        FindFirstObjectByType<playerEq>().deleteUI();
        FindFirstObjectByType<playerEq>().addItems();
        isBack = true;
    }

    private void Awake()
    {
        myButton.onClick.AddListener(ClearCombine);
    }
}
