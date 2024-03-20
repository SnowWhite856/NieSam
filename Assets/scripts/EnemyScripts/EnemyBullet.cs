using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public void bulletAttack()
    {
        //gameObject.GetComponent<BulletAnimation>().dmg = GetComponentInParent<EnemyClass>().damage;
        GameObject bullet = Resources.Load<GameObject>("Prefabs/Enemy/Bullet");
        GameObject bulletSpawner = GameObject.Find("bulletSpawner");

        GameObject bulletObj = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
    }
}
