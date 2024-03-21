using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        UnityEngine.Debug.Log(mesh.bounds.size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
