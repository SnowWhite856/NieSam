using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using System.Xml;

public class WarriorClass : MonoBehaviour
{
    public void addStats()
    {
        XmlDocument xml = new XmlDocument();
        xml.Load("Assets/Resources/saveFiles/PlayerStats.xml");

        XmlNode playerDmg = xml.SelectSingleNode("Player/dmg");
        XmlNode playerHp = xml.SelectSingleNode("Player/hp");
        XmlNode playerAp = xml.SelectSingleNode("Player/ap");
        XmlNode playerArmor = xml.SelectSingleNode("Player/armor");
        XmlNode playerMS = xml.SelectSingleNode("Player/movmentSpeed");

<<<<<<< HEAD
        playerDmg.InnerText = "15";
=======
        playerDmg.InnerText = "4";
>>>>>>> 92c62add1b385d0616aabda80c3c470ef9c0ab41
        playerHp.InnerText = "100";
        playerAp.InnerText = "2";
        playerArmor.InnerText = "30";
        playerMS.InnerText = "4";

        xml.Save("Assets/Resources/saveFiles/PlayerStats.xml");
        /*
        var player = FindFirstObjectByType<PlayerStats>();
        player.dmg = 4;
        player.ap = 2;
        player.hp = 100;
        player.armor = 30;
        player.movmentSpeed = 4;
        */
    }

    public void specialAbilyty()
    {

    }
}
