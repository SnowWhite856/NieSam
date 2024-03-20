using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using System.Xml;
using System;
using System.Reflection;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
   //statystki gracza
   public double dmg = 0;
   public double ap = 0;
   public double hp = 0;
   public double armor = 0;
   public double movmentSpeed = 0;

   public allPlayerClass playerClass;


    public enum allPlayerClass
    {
        Tank,
        Mage,
        Warrior,
        Thief
    }

    private void setStats()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("Assets/Resources/saveFiles/PlayerStats.xml");

        XmlNode root = xmlDoc.DocumentElement;
        XmlNodeList itemsList = root.SelectNodes("/*");

        FieldInfo[] fields = this.GetType().GetFields();

        foreach (XmlNode main in itemsList)
        {
            foreach (var field in fields)
            {
                Debug.Log(field.Name);
                foreach (XmlNode setData in main)
                {
                    if (field.Name == setData.Name)
                    {
                        object value = Convert.ChangeType(setData.InnerText, field.FieldType);
                        field.SetValue(this, value);
                    }
                }
            }
        }
    }

    private void Update()
    {
        if (hp <= 0)
        {
            FindFirstObjectByType<PlayerMovment>().canMove = false;

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("ClassScene");
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }


    //zmiana podczas zdjêcie przedmiotu
    public void TakeOffItem(itemsClass newItem, string type)
    {
        switch (type)
        {
            case "wapon":
                dmg -= newItem.GetComponent<WaponsClass>().attackDmg;
                ap -= newItem.GetComponent<WaponsClass>().ablilityDmg; break;

            case "armor":
                hp -= newItem.GetComponent<ArmourClass>().hp;
                armor -= newItem.GetComponent<ArmourClass>().armor; break;
        }
    }

    //zmiana podczas za³o¿enia przedmiotu
    public void TakeOnItem(itemsClass newItem, string type)
    {
        switch (type)
        {
            case "wapon":
                dmg += newItem.GetComponent<WaponsClass>().attackDmg;
                ap += newItem.GetComponent<WaponsClass>().ablilityDmg;break;

            case "armor":
                hp += newItem.GetComponent<ArmourClass>().hp;
                armor += newItem.GetComponent<ArmourClass>().armor;break;

        }
    }

    //zamiana statysyk gracza wzglendem klasy
    public void Start()
    {
        //pobieranie klasy z pliku
        string path = "Assets/Resources/saveFiles/ClassSave.txt";
        StreamReader render = new StreamReader(path);
        string classType = render.ReadLine();
        render.Close();
        //Debug.Log(classType);

        //ustawianie statystk wzglêdem klasy postaci
        switch (classType)
        {
            case "Tank":
                FindFirstObjectByType<TankClass>().addStats();
                playerClass = allPlayerClass.Tank;
                break;

            case "Mage":
                FindFirstObjectByType<MageClass>().addStats();
                playerClass = allPlayerClass.Mage;
                break;

            case "Warrior":
                FindFirstObjectByType<WarriorClass>().addStats();
                playerClass = allPlayerClass.Warrior;
                break;

            case "Thief":
                FindFirstObjectByType<ThiefClass>().addStats();
                playerClass = allPlayerClass.Thief;
                break;
        }
        setStats();
    }
}
