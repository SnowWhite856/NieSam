using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CreateItemBtn : MonoBehaviour
{
    public Button myButton;
    public TextMeshProUGUI newItemName;
    private string path = "Assets/Resources/saveFiles/craftings.xml";

    private void craftItem()
    {
        var item = FindObjectOfType<EqScipt>().item;
        List<string> needItems = new List<string>();
        List<string> tempItems = new List<string>();
        List<GameObject> itemsToRemove = new List<GameObject>();

        //otwieranie danych z xml
        XDocument doc = XDocument.Load(path);

        XElement item2Element = doc.Descendants(newItemName.text).First();

        //pobieranie przedmiotów potrzebnych do tworzenia
        foreach (XElement node in item2Element.Elements())
        {
            needItems.Add(node.Attribute("name").Value);
            tempItems.Add(node.Attribute("name").Value);
        }

        //sprawdzanie czy gracz ma potzrebne przemioty
        foreach (var currentItem in item)
        {
            foreach(var toFind in needItems)
            {
                if(currentItem.name == toFind)
                {
                    tempItems.Remove(currentItem.name);
                    itemsToRemove.Add(currentItem);
                }
            }
        }

        //tworzenie przedmiotu
        if (tempItems.Count == 0)
        {
            //usówanie u¿ytch przedmiotów
            foreach(var toRemove in itemsToRemove)
            {
                item.Remove(toRemove);
            }
            //dodawnie nowego przedmiotu
            var newItem = newItemName.text;
            var itemPath = "Prefabs/" + newItem;
            GameObject prefab = Resources.Load<GameObject>(itemPath);
            item.Add(prefab);
        }

        needItems.Clear();
        tempItems.Clear();
        itemsToRemove.Clear();
    }

    private void Awake()
    {
        myButton.onClick.AddListener(craftItem);
    }
}
