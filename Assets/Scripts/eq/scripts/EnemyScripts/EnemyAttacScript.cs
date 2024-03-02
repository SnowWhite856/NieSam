using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacScript : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player") return;
        var enemy = FindFirstObjectByType<Enemy1Script>();
        enemy.enemyStatus = "Attack";
        enemy.target = other.gameObject;
        Debug.Log("attack player");
    }

    
    private void OnTriggerExit(Collider other)
    {
        var enemy = FindFirstObjectByType<Enemy1Script>().enemyStatus = "Chase";

    }
    
}
