using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Xml;
using System.Xml.Linq;
using System;

public class EnemyWaves : MonoBehaviour
{
    public TextAsset xmlFile;
    private int currentWave = 0;
    private string WaveToRead;
    public int meleEnemyCount = 0;
    public int rangeEnemyCount = 0;
    public int enemysLeft = 0;

    private void Update()
    {
        if (enemysLeft == 0 && Input.GetKeyDown(KeyCode.P))
        {
            GameObject.Find("door").GetComponentInChildren<MeshRenderer>().enabled = true;
       
            currentWave++;
            WaveToRead = "waves/wave" + currentWave;
            ReadWaveData(xmlFile.text);
        }

        if (enemysLeft == 0)
        {
            GameObject.Find("door").GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }

    void ReadWaveData(string xmlData)
    {
        try
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlData);

            XmlNode wave1Node = xmlDoc.SelectSingleNode(WaveToRead);

            if (wave1Node != null)
            {
                meleEnemyCount = int.Parse(wave1Node.SelectSingleNode("MeleEnemy").InnerText);

                rangeEnemyCount = int.Parse(wave1Node.SelectSingleNode("RangeEnemy").InnerText);
            }
            else
            {
                Debug.LogError("wave1 node not found in the XML");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error parsing XML: {e.Message}");
        }

        Debug.Log($"MeleEnemy in wave" + currentWave + $" : {meleEnemyCount}");
        Debug.Log($"RangeEnemy in wave" + currentWave + $": {rangeEnemyCount}");

        FindFirstObjectByType<CratingEnemyWaves>().StartWave();
    }
}
