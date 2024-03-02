using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RangeEnemyClass : EnemyClass
{
    private bool isOnAttack = false;
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
        yield return new WaitForSeconds(2);
        isOnAttack=false;
    }
}
