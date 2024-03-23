using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System;
using UnityEngine;
using System.Xml.Linq;
using Unity.VisualScripting;

public class ItemsSave : MonoBehaviour
{
    private int reps = 0;

    private void Start()
    {
        var items = FindFirstObjectByType<EqScipt>().item;

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("Assets/Resources/saveFiles/Items.xml");

        XmlNode root = xmlDoc.DocumentElement;

        XmlNodeList itemsList = root.SelectNodes("/*");
        //XmlNodeList test;

        foreach (XmlNode itemNode in itemsList)
        {
            foreach (XmlNode child in itemNode)
            {
                reps++;
                var path = "Prefabs/"+child.Name;
                //Debug.Log(path);
                GameObject prefab = Resources.Load<GameObject>(path);
                items.Add(prefab.GetComponent<itemsClass>());
 
                Type type = items[items.Count-1].GetType();
                FieldInfo[] fields = type.GetFields();

                //test = root.DocumentElement.SelectNodes(child,"id",reps);
                foreach (var field in fields)
                {
                    foreach(XmlNode childData in child)
                    {
                        if(field.Name == childData.Name && childData.Attributes["id"].Value == child.Attributes["id"].Value)
                        {
                            object value = Convert.ChangeType(childData.InnerText, field.FieldType);
                            //Debug.Log(field.Name + " "+value.ToString());
                            itemsClass tempItem = items[items.Count - 1].GetComponent<itemsClass>();
                            field.SetValue(tempItem, value);
                            break;
                        }
                    }
                }
            }
        }
        reps = 0;
    }
}
