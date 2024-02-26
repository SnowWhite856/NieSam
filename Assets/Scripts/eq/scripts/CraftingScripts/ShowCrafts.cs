using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class ShowCrafts : MonoBehaviour
{
    public Canvas craftingUI;

    public Transform grid;
    private GameObject EqItem;
    private bool isOn = true;


    private void Start()
    {
        craftingUI.GetComponent<Canvas>().enabled = false;
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            var obj = FindObjectOfType<playerEq>();
            if (isOn)
            {
                obj.GetComponent<PlayerMovment>().canMove = false;
                craftingUI.GetComponent<Canvas>().enabled = true;
                Cursor.lockState = CursorLockMode.None;
                showCrafts();
                isOn = false;
            }
            else
            {
                obj.GetComponent<PlayerMovment>().canMove = true;
                craftingUI.GetComponent<Canvas>().enabled = false;
                Cursor.lockState = CursorLockMode.Locked;
                destroyItems();
                isOn = true;
            }
        }
        
    }

    public string path = "Assets/Resources/saveFiles/craftings.xml";
    void showCrafts()
    {
        
        XDocument doc = XDocument.Load(path);

        XElement item2Element = doc.Descendants("items").First();
        //XElement item2Element = doc.Descendants("item2").First();

        foreach (XElement node in item2Element.Elements())
        {
            GameObject eqItem;
            EqItem = GameObject.FindGameObjectWithTag("CraftItemTag");
            TextMeshProUGUI text;
            eqItem = Instantiate(EqItem, grid);
            text = eqItem.GetComponentInChildren<TextMeshProUGUI>();
            eqItem.name = node.Attribute("name").Value.ToString();
            text.text = node.Attribute("name").Value.ToString();

        }
    }

    private void destroyItems()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("CraftItemTag");

        for (int i = 1; i < obj.Length; i++)
        {
            Destroy(obj[i]);
        }
    }
}
