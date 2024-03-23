using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Linq;
using System.Linq;

public class dialougeScript : MonoBehaviour
{
    public TextMeshProUGUI dialougePlace;
    public Button myButton;

    private int currentDialouge = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            dialougePlace.enabled = false;
            myButton.enabled = false;
        }
    }
    public void shopOn()
    {
        dialougePlace.enabled = true;
        myButton.enabled = true;

        XDocument doc = XDocument.Load("Assets/Resources/saveFiles/shopDialouge.xml");

        XElement textElement = doc.Descendants("text").Where(x => x.Attribute("id")?.Value == currentDialouge.ToString()).FirstOrDefault();

        dialougePlace.text = textElement.Value;
    }

    public void nextDialouge()
    {
        currentDialouge++;
        if (currentDialouge >= 5)
        {
            currentDialouge = 1;
        }
        shopOn();
    }

    private void Awake()
    {
        myButton.onClick.AddListener(nextDialouge);
    }
}