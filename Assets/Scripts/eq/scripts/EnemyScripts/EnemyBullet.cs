using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public void bulletAttack()
    {
        GameObject bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        GameObject bulletSpawner = GameObject.Find("Capsule");
        bulletSpawner = Instantiate(bullet , bulletSpawner.transform);
        //bulletSpawner.transform.Translate(Vector3.forward * 19.0f * Time.deltaTime);
    }
}
