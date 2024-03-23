using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor.PackageManager;
using UnityEngine;

public class ThiefClass : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    public void addStats()
    {
        XmlDocument xml = new XmlDocument();
        xml.Load("Assets/Resources/saveFiles/PlayerStats.xml");

        XmlNode playerDmg = xml.SelectSingleNode("Player/dmg");
        XmlNode playerHp = xml.SelectSingleNode("Player/hp");
        XmlNode playerAp = xml.SelectSingleNode("Player/ap");
        XmlNode playerArmor = xml.SelectSingleNode("Player/armor");
        XmlNode playerMS = xml.SelectSingleNode("Player/movmentSpeed");

        playerDmg.InnerText = "15";
        playerHp.InnerText = "85";
        playerAp.InnerText = "2";
        playerArmor.InnerText = "20";
        playerMS.InnerText = "7";

        xml.Save("Assets/Resources/saveFiles/PlayerStats.xml");
        /*
        var player = FindFirstObjectByType<PlayerStats>();
        player.dmg = 4;
        player.ap = 2;
        player.hp = 85;
        player.armor = 20;
        player.movmentSpeed = 7;
        */
    }

    public void specialAbilyty()
    {
    /*
        var player = GetComponentInParent<PlayerMovment>();
        Debug.Log("Thief abilyty");
        player.transform.Translate(Vector3.right * 100f * Time.deltaTime);
        anim.SetTrigger("ThiefDash");
    */
    }
}
