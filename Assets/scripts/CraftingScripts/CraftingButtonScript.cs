using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingButtonScript : MonoBehaviour
{
    public Button myButton;

    public TextMeshProUGUI itemNameSlot;
    public TextMeshProUGUI neededItemsSlot;
    public string path = "Assets/Resources/saveFiles/craftings.xml";

    void showCraftsBtn()
    {
        neededItemsSlot.text = "Materials to craft: ";
        itemNameSlot.text = myButton.name;
        XDocument doc = XDocument.Load(path);

        XElement item2Element = doc.Descendants(myButton.name).First();

        foreach (XElement node in item2Element.Elements())
        {
            neededItemsSlot.text += node.Attribute("name").Value + ", ";
        }
    }

    private void Awake()
    {
        myButton.onClick.AddListener(showCraftsBtn);
    }
}
