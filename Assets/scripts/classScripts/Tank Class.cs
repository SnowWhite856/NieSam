using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor.PackageManager;
using UnityEngine;

public class TankClass : MonoBehaviour
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

        playerDmg.InnerText = "8";
        playerHp.InnerText = "150";
        playerAp.InnerText = "1";
        playerArmor.InnerText = "50";
        playerMS.InnerText = "3";

        xml.Save("Assets/Resources/saveFiles/PlayerStats.xml");
        /*
        var player = FindFirstObjectByType<PlayerStats>();
        player.dmg = 2;
        player.ap = 1;
        player.hp = 150;
        player.armor = 50;
        player.movmentSpeed = 3;
        */
    }

    public void specialAbilyty()
    {

    }
}
