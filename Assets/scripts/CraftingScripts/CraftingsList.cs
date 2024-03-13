using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

public class CraftingsList : MonoBehaviour
{
    public string path = "Assets/Resources/saveFiles/craftings.xml";

    private void Start()
    {
        XDocument doc = XDocument.Load(path);

        XElement item2Element = doc.Descendants("items").First();
        //XElement item2Element = doc.Descendants("item2").First();

        foreach (XElement node in item2Element.Elements())
        {
           // Debug.Log(node.Attribute("name").Value);
        }
    }
}
