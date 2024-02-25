using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoCombineBtn : MonoBehaviour
{
    public Button myButton;
    public TextMeshProUGUI Info;
    public List<GameObject> crafts = new List<GameObject>();
    //public GameObject item3;
    public void doCombine()
    {
        var item1 = FindObjectOfType<CombineBtnScript>().toCombine[0];
        var item2 = FindObjectOfType<CombineBtnScript>().toCombine[1];
        var item = FindObjectOfType<EqScipt>().item;

        var clear = FindObjectOfType<ClearCombinieBtnScript>();

        if (item1 != null && item2 != null)
        {
            if(item1.name == "item1" && item2.name == "item2")
            {
                item.Add(crafts[2]);
                clear.isBack = false;
                clear.ClearCombine();
            }
            else if(item1.name == "item1" && item2.name == "item3") 
            {
                item.Add(crafts[1]);
                clear.isBack = false;
                clear.ClearCombine();
            }
            else if (item1.name == "item2" && item2.name == "item3")
            {
                item.Add(crafts[0]);
                clear.isBack = false;
                clear.ClearCombine();
            }
            else
            {
                Info.text = "Items cannot be combined";
                clear.ClearCombine();
            }
        }
    }
    private void Awake()
    {
        myButton.onClick.AddListener(doCombine);
    }
}
