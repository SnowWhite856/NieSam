using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class itemsClass : MonoBehaviour
{
    public string name;
    public bool stack;
    public int stackLimit;
    public string Description;
   // public Image spriteImage;
    public int Id;

    private int reps = 0;

    public itemsClass(string name, bool stack, int stackLimit, string Description) {
        this.name = name;
        this.stack = stack;
        this.stackLimit = stackLimit;
        this.Description = Description;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            var itemsInEq = FindFirstObjectByType<EqScipt>().item;
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load("Assets/Resources/saveFiles/Items.xml");
            XmlNode root = xmlDoc.DocumentElement;
            root.RemoveAll();
            xmlDoc.Save("Assets/Resources/saveFiles/Items.xml");

            xmlDoc.Load("Assets/Resources/saveFiles/Items.xml");
            foreach (var item in itemsInEq)
            {
                reps++;
                Type type = item.GetType();
                FieldInfo[] fields = type.GetFields();

                XmlNode playerNode = xmlDoc.SelectSingleNode("Items");
                XmlNode itemNode = xmlDoc.CreateElement(item.name);

                ((XmlElement)itemNode).SetAttribute("id", reps.ToString());

                foreach (FieldInfo field in fields)
                {
                    XmlNode itemValue = xmlDoc.CreateElement(field.Name);
                    ((XmlElement)itemValue).SetAttribute("id", reps.ToString());
                    object value = field.GetValue(item);
                    itemValue.InnerText = value.ToString();
                    itemNode.AppendChild(itemValue);
                }

                playerNode.AppendChild(itemNode);
            }
            xmlDoc.Save("Assets/Resources/saveFiles/Items.xml");
            reps = 0;
        }
    }
}
