using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerStats;

public class PlayerMovment : MonoBehaviour
{
    public bool canMove = true;
    public float xRotation = 0;
    public float yRotation = 0;
    public int movmentSpeed = 3;
    public allPlayerClass playerClass;

    private void Start()
    {
        playerClass = FindFirstObjectByType<PlayerStats>().playerClass;
        Cursor.lockState = CursorLockMode.Locked;
        //movmentSpeed = GetComponent<PlayerStats>().movmentSpeed;
        //canMove = true;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canMove) return;
        movmentSpeed = FindFirstObjectByType<PlayerStats>().movmentSpeed;
        //Debug.Log(canMove);
        //var player = FindObjectOfType<PlayerMovment>();
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += gameObject.transform.forward * 15f * movmentSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += gameObject.transform.forward * -15f * movmentSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += gameObject.transform.right * -15f * movmentSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += gameObject.transform.right * 15f * movmentSpeed;
        }

        xRotation += Input.GetAxis("Mouse X") * Time.deltaTime * 220f;

        yRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * -220f;

        transform.rotation = Quaternion.Euler(yRotation, xRotation, 0);
        gameObject.GetComponent<Rigidbody>().AddForce(direction);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log(playerClass);
            switch (playerClass)
            {
                case allPlayerClass.Tank:
                    FindFirstObjectByType<TankClass>().specialAbilyty();
                    playerClass = allPlayerClass.Tank;
                    break;

                case allPlayerClass.Mage:
                    FindFirstObjectByType<MageClass>().specialAbilyty();
                    playerClass = allPlayerClass.Mage;
                    break;

                case allPlayerClass.Warrior:
                    FindFirstObjectByType<WarriorClass>().specialAbilyty();
                    playerClass = allPlayerClass.Warrior;
                    break;

                case allPlayerClass.Thief:
                    FindFirstObjectByType<ThiefClass>().specialAbilyty();
                    playerClass = allPlayerClass.Thief;
                    break;
            }
        }
    }
}