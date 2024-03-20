using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor.PackageManager;
using UnityEngine;

public class MageClass : PlayerStats
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

        playerDmg.InnerText = "1";
        playerHp.InnerText = "80";
        playerAp.InnerText = "4";
        playerArmor.InnerText = "15";
        playerMS.InnerText = "3";

        xml.Save("Assets/Resources/saveFiles/PlayerStats.xml");

        /*
        var player = FindFirstObjectByType<PlayerStats>();
        player.dmg = 1;
        player.ap = 4;
        player.hp = 80;
        player.armor = 15;
        player.movmentSpeed = 3;
        */
    }

    public void specialAbilyty()
    {

    }
}
