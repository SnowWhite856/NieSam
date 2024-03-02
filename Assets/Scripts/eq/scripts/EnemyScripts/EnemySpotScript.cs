using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpotScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var enemy = FindFirstObjectByType<Enemy1Script>();
        if (other.name != "Player") return;
        enemy.enemyStatus = "Chase";
        enemy.target = other.gameObject;
        Debug.Log("player found");
    }

    private void OnTriggerExit(Collider other)
    {
        var enemy = FindFirstObjectByType<Enemy1Script>().enemyStatus = "Patroling";

    }
}
