using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletAnimation : MonoBehaviour
{
    public float speed = 15.0f;
    public double dmg = 10;

    private void Start()
    {
        StartCoroutine(destroyBullet());
    }
    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //FindFirstObjectByType<PlayerStats>().hp;
<<<<<<< HEAD
        if (other.name != "Player") return;
=======
>>>>>>> 92c62add1b385d0616aabda80c3c470ef9c0ab41
        dmg = FindFirstObjectByType<RangeEnemyClass>().damage;
        double absorbDmg = FindFirstObjectByType<PlayerStats>().armor;

        double currentHp = FindFirstObjectByType<PlayerStats>().hp;

        Debug.Log("player hp: " + currentHp + " dmg taken: "+dmg+ " aborbe dmg:" +absorbDmg + " total dmg: "+ Math.Round(dmg - absorbDmg / 5));

        FindFirstObjectByType<PlayerStats>().hp -= Math.Round(dmg - absorbDmg/5);
<<<<<<< HEAD
=======

        //Debug.Log("current hp: " + currentHp);
        //Debug.Log("player hit!");
>>>>>>> 92c62add1b385d0616aabda80c3c470ef9c0ab41
    }
}
