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
    public float lookRadius = 20f;  
    public bool IsEnemyKnow = false;

    private int movmentSpeed = 3;
    private bool reachDestination = true;
    private Vector3 randomPoint;
    private bool isDead = false;
   // private bool isOnAttack = false;

    public allEnemyStatus enemyStatus;

    private void Start()
    {
        FindFirstObjectByType<EnemyWaves>().enemysLeft++;
        enemyStatus = allEnemyStatus.Chase;
        movmentSpeed = GetComponent<EnemyClass>().movmentSpeed;
        GetComponent<NavMeshAgent>().speed = movmentSpeed;
        target = GameObject.Find("Player");
        agent.SetDestination(target.transform.position);
    }

    public enum allEnemyStatus
    {
        Patroling,
        Chase,
        Attack,
        dead
    }

    private bool canTakeDmg = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" || enemyStatus == allEnemyStatus.dead || !canTakeDmg) return;
        canTakeDmg = false;
        WaponsClass takDmage = FindFirstObjectByType<EqScipt>().currentWapon;
        gameObject.GetComponent<EnemyClass>().hp -= takDmage.GetComponent<WaponsClass>().attackDmg;
        /*
        if(gameObject.GetComponent<EnemyClass>().hp <= 0)
        {
            enemyStatus = allEnemyStatus.dead;
        }
        */
        //Debug.Log("enemy hit!");
        StartCoroutine(waitDmg());
    }

    IEnumerator waitDmg()
    {
        yield return new WaitForSeconds(1);
        canTakeDmg = true;
    }

    void FixedUpdate()
    {
        if(gameObject.GetComponent<EnemyClass>().hp <= 0)
        {
            enemyStatus = allEnemyStatus.dead;
        }

        switch (enemyStatus)
        {
            case allEnemyStatus.Patroling:
                patroling();
                break;

            case allEnemyStatus.Chase:
                chase();
                break;

            case allEnemyStatus.Attack:
                attack();
                break;

            case allEnemyStatus.dead:
                dead();
                break;
        }
    }

    void dead()
    {
        if(isDead) return;
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        FindFirstObjectByType<EnemyWaves>().enemysLeft -= 1;
        isDead = true;
    }

    //enemy patroling
    public float radius = 35.0f;
    void patroling()
    {
        if(isDead) return;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, lookRadius);
    }

    //enemy chaseing player
    private void chase()
    {
        if (isDead) return;
        if (gameObject.tag == "Range") enemyStatus = allEnemyStatus.Attack;

        agent.SetDestination(target.transform.position);
        IsEnemyKnow = true;

        float distance = Vector3.Distance(target.transform.position, transform.position);

        /*
        if (distance >= lookRadius)
        {
            enemyStatus = allEnemyStatus.Patroling;
            IsEnemyKnow = false;
        }
        */
    }

    //enemy attack
    private void attack()
    {
        if (!IsEnemyKnow) return;
        if (isDead) return;

            Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = rotation;
        if (IsEnemyKnow)
        {
        }

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

        /*
        if (distance >= lookRadius)
        {
            enemyStatus = allEnemyStatus.Patroling;
            IsEnemyKnow = false;
        }
        */
    }
}