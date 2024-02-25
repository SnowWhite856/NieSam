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
        var item = FindObjectOfType<EqScipt>().item;

        for (int i = 0; i < 2; i++)
        {
            if(FindObjectOfType<CombineBtnScript>().toCombine[i] != null)
            {
                if (isBack)
                {
                    item.Add(FindObjectOfType<CombineBtnScript>().toCombine[i]);
                }
                FindObjectOfType<CombineBtnScript>().toCombine[i] = null;
            }
        }

        FindObjectOfType<playerEq>().deleteUI();
        FindObjectOfType<playerEq>().addItems();
        isBack = true;
    }

    private void Awake()
    {
        myButton.onClick.AddListener(ClearCombine);
    }
}
