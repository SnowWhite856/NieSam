using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemyClass : EnemyClass
{
    private bool isOnAttack = false;
    private int attackTime = 3;

    private void Start()
    {
        attackTime = GetComponent<EnemyClass>().attackSpeed;
    }

    public void MeleAttack()
    {
        Animator anim;
        anim = GetComponent<Animator>();

        //Debug.Log("attack");
        if (isOnAttack) return;
        isOnAttack = true;
        StartCoroutine(attackPlayerCd(anim));
    }

    IEnumerator attackPlayerCd(Animator anim)
    {
        yield return new WaitForSeconds(attackTime);
        anim.SetTrigger("Attack");
        isOnAttack = false;
    }

}
