using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class TankClass : PlayerStats
{
    public void addStats()
    {
        var player = FindFirstObjectByType<PlayerStats>();
        player.dmg = 2;
        player.ap = 1;
        player.hp = 150;
        player.armor = 50;
        player.movmentSpeed = 3;
    }

    public void specialAbilyty()
    {

    }
}
