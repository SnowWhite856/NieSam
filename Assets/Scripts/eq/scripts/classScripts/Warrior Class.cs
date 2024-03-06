using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class WarriorClass : PlayerStats
{
    public void addStats()
    {
        var player = FindFirstObjectByType<PlayerStats>();
        player.dmg = 4;
        player.ap = 2;
        player.hp = 100;
        player.armor = 30;
        player.movmentSpeed = 4;
    }

    public void specialAbilyty()
    {

    }
}
