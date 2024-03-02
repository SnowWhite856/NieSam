using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class Enemy1Script : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    
    public bool IsEnemyKnow = false;

    private bool reachDestination = true;
    private Vector3 randomPoint;
    private bool isOnAttack = false;

    public string enemyStatus = "Patroling";

    

    void FixedUpdate()
    {
        switch (enemyStatus)
        {
            case "Patroling":
                patroling();
                break;

            case "Chase":
                chase();
                break;

            case "Attack":
                attack();
                break;
        }

        if (gameObject.tag == "Range" && enemyStatus == "Chase") enemyStatus = "Attack"; 

        if (enemyStatus == "Attack" && IsEnemyKnow)
        {
            Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = rotation;
        }
    }
    public float radius = 35.0f;

    void patroling()
    {
        var currentX = target.transform.position.x;
        var currentZ = target.transform.position.z;

        if (reachDestination)
        {
            reachDestination = false;
            float randomX = Random.Range(-15, 15);
            float randomZ = Random.Range(-15, 15);
            float randomY = target.transform.position.y;

            randomPoint = new Vector3(currentX+randomX, randomY, currentZ+randomZ);

            agent.SetDestination(randomPoint);
            StartCoroutine(destinationFunc());
        }
    }

    IEnumerator destinationFunc()
    {
        yield return new WaitForSeconds(4);
        agent.SetDestination(agent.transform.position);
        yield return new WaitForSeconds(2);
        reachDestination=true;
    }

    public float lookRadius = 20f;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, lookRadius);
    }

    private void chase()
    {
        Debug.Log("player spot");
        agent.SetDestination(target.transform.position);
        IsEnemyKnow = true;

        float distance = Vector3.Distance(target.transform.position, transform.position);

        if (distance >= lookRadius)
        {
            enemyStatus = "Patroling";
            IsEnemyKnow = false;
        }
    }

    private void attack()
    {
        if (!IsEnemyKnow) return;
       
        agent.SetDestination(agent.transform.position);
        float distance = Vector3.Distance(target.transform.position, transform.position);

        switch (gameObject.tag)
        {
            case "Range":
                if (distance <= lookRadius)
                {
                    gameObject.GetComponent<RangeEnemyClass>().RangeAttack();
                }
                break;

            case "Mele":
                gameObject.GetComponent<MeleEnemyClass>().MeleAttack();
                break;
        }

        if (distance >= lookRadius)
        {
            enemyStatus = "Patroling";
            IsEnemyKnow = false;
        }
    }
}