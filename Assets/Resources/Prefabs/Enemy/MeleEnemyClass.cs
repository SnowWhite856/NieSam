using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemyClass : EnemyClass
{
    private bool isOnAttack = false;

    public void MeleAttack()
    {
        Animator anim;
        anim = GetComponent<Animator>();

        Debug.Log("attack");
        if (isOnAttack) return;
        isOnAttack = true;
        StartCoroutine(attackPlayerCd(anim));
    }

    IEnumerator attackPlayerCd(Animator anim)
    {
        yield return new WaitForSeconds(2);
        anim.SetTrigger("Attack");
        isOnAttack = false;
    }

}
