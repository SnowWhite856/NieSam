using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public bool canMove = true;
    public float xRotation = 0;
    public float yRotation = 0;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canMove = true;
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!canMove) return;
        //Debug.Log(canMove);
        //var player = FindObjectOfType<PlayerMovment>();
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += gameObject.transform.forward * 8;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction += gameObject.transform.forward * -1;
        }

        xRotation += Input.GetAxis("Mouse X") * Time.deltaTime * 220f;

        yRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * -220f;

        transform.rotation = Quaternion.Euler(yRotation, xRotation, 0);
        gameObject.GetComponent<Rigidbody>().AddForce(direction);


    }
}
