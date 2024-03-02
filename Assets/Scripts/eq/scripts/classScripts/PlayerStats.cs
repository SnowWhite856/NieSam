using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //statystki gracza
   public int dmg = 0;
   public int ap = 0;
   public int hp = 0;
   public int armor = 0;
   public int movmentSpeed = 0;

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
        Debug.Log(classType);
        //ustawianie statystk wzglêdem klasy postaci
        switch (classType)
        {
            case "Tank":
                dmg = 2;
                ap = 1;
                hp = 150;
                armor = 50;
                movmentSpeed = 3; break;

            case "Mage":
                dmg = 1;
                ap = 4;
                hp = 80;
                armor = 15;
                movmentSpeed = 3; break;

            case "Warrior":
                dmg = 4;
                ap = 2;
                hp = 100;
                armor = 30;
                movmentSpeed = 4; break;

            case "Thief":
                dmg = 4;
                ap = 2;
                hp = 85;
                armor = 20;
                movmentSpeed = 7; break;
        }
    }
}
