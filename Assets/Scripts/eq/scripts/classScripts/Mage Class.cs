using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class MageClass : PlayerStats
{
    public void addStats()
    {
        var player = FindFirstObjectByType<PlayerStats>();
        player.dmg = 1;
        player.ap = 4;
        player.hp = 80;
        player.armor = 15;
        player.movmentSpeed = 3;
    }

    public void specialAbilyty()
    {

    }
}
