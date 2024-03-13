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

   public allPlayerClass playerClass;

    public enum allPlayerClass
    {
        Tank,
        Mage,
        Warrior,
        Thief
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
    }
}
