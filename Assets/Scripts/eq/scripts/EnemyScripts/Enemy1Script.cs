using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1Script : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public float radius = 35.0f;
    private bool reachDestination = true;
    private Vector3 randomPoint;

    public string enemyStatus = "Patroling";
    void Update()
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
    }

    void patroling()
    {
        if (reachDestination)
        {
            reachDestination = false;
            float randomX = Random.Range(10, radius);
            float randomZ = Random.Range(20, radius);
            float randomY = target.transform.position.y;
            randomPoint = new Vector3(randomX, randomY, randomZ);
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

    private void chase()
    {
        agent.SetDestination(target.transform.position);
    }

    private void attack()
    {
        agent.SetDestination(agent.transform.position);
        StartCoroutine(attackPlayerCd());
    }

    IEnumerator attackPlayerCd()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<EnemyBullet>().bulletAttack();
        Debug.Log("attack");
    }
}