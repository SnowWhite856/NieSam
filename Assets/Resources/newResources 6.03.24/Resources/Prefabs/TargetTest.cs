using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Spear")
        {
            Debug.Log("Hit");
        }
    }
}
