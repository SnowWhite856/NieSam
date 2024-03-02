using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public void bulletAttack()
    {
        GameObject bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        GameObject bulletSpawner = GameObject.Find("bulletSpawner");
        bulletSpawner = Instantiate(bullet , bulletSpawner.transform);
    }
}
