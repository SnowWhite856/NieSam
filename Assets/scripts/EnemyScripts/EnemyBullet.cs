using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public void bulletAttack()
    {
        GameObject bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        GameObject bulletSpawner = GameObject.Find("bulletSpawner");

        GameObject bulletObj = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
    }
}
