using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RangeEnemyClass : EnemyClass
{
    private bool isOnAttack = false;
    private int attackTime = 3;

    private void Start()
    {
        attackTime = GetComponent<EnemyClass>().attackSpeed;
    }

    private bool canTeleport = false;

    private void Update()
    {
        RangeAttack();
        if (!canTeleport)
        {
            Invoke(nameof(enemyTeleport), 20);
            enemyTeleport();
            canTeleport = true;
        }
    }

    void enemyTeleport()
    {
        int randomX = Random.Range(-267, -117);
        int randomZ = Random.Range(-85, 86);

        gameObject.transform.position = new Vector3(randomX, gameObject.transform.position.y, randomZ);
        canTeleport = false;
    }
    public void RangeAttack()
    {
        if (isOnAttack) return;
        isOnAttack = true;
        StartCoroutine(attackPlayerCd());
    }

    IEnumerator attackPlayerCd()
    {
        FindFirstObjectByType<EnemyBullet>().bulletAttack();
        //Debug.Log("attack");
        yield return new WaitForSeconds(attackTime);
        isOnAttack=false;
    }
}
