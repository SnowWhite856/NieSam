using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class ClassChoose : MonoBehaviour
{
    public string classDescription;
    public TextMeshProUGUI classInfo;

    public void playerChoose()
    {
        //zapisywanie klasy do pliku
        string path = "Assets/Resources/saveFiles/ClassSave.txt";
        string classType = gameObject.name;
        StreamWriter writer = new StreamWriter(path);
        writer.WriteLine(classType);
        writer.Close();
        
        //³adowanie gry
        SceneManager.LoadScene("BattleTest1");
    }

    private void OnMouseEnter()
    {
        //gameObject.transform.position = Vector3.up*1.5f;
        classInfo.text = classDescription;
    }

    private void OnMouseExit()
    {
        classInfo.text = "";
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
        playerChoose();
    }
    /*
    public void Awake()
    {
        myButton.onClick.AddListener(playerChoose);
    }
*/
}
