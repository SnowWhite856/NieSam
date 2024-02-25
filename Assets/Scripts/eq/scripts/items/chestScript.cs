using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class chestScript : MonoBehaviour
{
    private string newWappon;
    private void Start()
    {
        int rn = Random.Range(1, 100);

        if(rn < 50)
        {
            newWappon = "sword";
        }
        else
        {
            newWappon = "shield";
        }
    }
    private void OnMouseDown()
    {
        var path = "Prefabs/" + newWappon;
        //Debug.Log(path);
        GameObject prefab = Resources.Load<GameObject>(path);
        Vector3 location = gameObject.transform.position;
        Instantiate(prefab, location, Quaternion.identity);
        Destroy(gameObject);
        }
}
