using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CratingEnemyWaves : MonoBehaviour
{
    public void StartWave()
    {
        int numbOfMeleEnemys = FindFirstObjectByType<EnemyWaves>().meleEnemyCount;
        int numbOfRangeEnemys = FindFirstObjectByType<EnemyWaves>().rangeEnemyCount;

        var pathMele = "Prefabs/Enemy/MeleEnemy";
        var pathRange = "Prefabs/Enemy/RangeEnemy";
        for (int i = 0;i<numbOfMeleEnemys;i++)
        {
            int randomX = Random.Range(-267,-117);
            int randomZ = Random.Range(-85,86);
            GameObject prefab = Resources.Load<GameObject>(pathMele);
            Vector3 spawn = new Vector3(randomX,0,randomZ);
            Instantiate(prefab, spawn, Quaternion.identity);
        }

        for (int i = 0; i < numbOfRangeEnemys; i++)
        {
            int randomX = Random.Range(-267, -117);
            int randomZ = Random.Range(-85, 86);
            GameObject prefab = Resources.Load<GameObject>(pathRange);
            Vector3 spawn = new Vector3(randomX, 0, randomZ);
            Instantiate(prefab, spawn, Quaternion.identity);
        }
    }
}
