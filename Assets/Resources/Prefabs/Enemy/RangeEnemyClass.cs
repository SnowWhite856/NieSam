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

    public void RangeAttack()
    {
        if (isOnAttack) return;
        isOnAttack = true;
        StartCoroutine(attackPlayerCd());
    }

    IEnumerator attackPlayerCd()
    {
        FindFirstObjectByType<EnemyBullet>().bulletAttack();
        Debug.Log("attack");
        yield return new WaitForSeconds(attackTime);
        isOnAttack=false;
    }
}
