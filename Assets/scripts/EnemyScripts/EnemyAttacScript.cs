using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacScript : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player") return;
        var enemy = GetComponentInParent<Enemy1Script>();
        enemy.enemyStatus = Enemy1Script.allEnemyStatus.Attack;
        enemy.target = other.gameObject;
        Debug.Log("attack player");
    }

    
    private void OnTriggerExit(Collider other)
    {
        var enemy = GetComponentInParent<Enemy1Script>().enemyStatus = Enemy1Script.allEnemyStatus.Chase;

    }
    
}
