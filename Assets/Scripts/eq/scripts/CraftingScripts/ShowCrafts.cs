using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCrafts : MonoBehaviour
{
    public Canvas craftingUI;
    public Transform allCraftings;
    private bool isOn = true;

    private void Start()
    {
        craftingUI.GetComponent<Canvas>().enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            var obj = FindObjectOfType<playerEq>();
            if (isOn)
            {
                obj.GetComponent<PlayerMovment>().canMove = false;
                craftingUI.GetComponent<Canvas>().enabled = true;
                Cursor.lockState = CursorLockMode.None;
                showCrafts();
                isOn = false;
            }
            else
            {
                obj.GetComponent<PlayerMovment>().canMove = true;
                craftingUI.GetComponent<Canvas>().enabled = false;
                Cursor.lockState = CursorLockMode.Locked;
                isOn = true;
            }
        }

        void showCrafts()
        {
            /*
            var numbOfList = FindObjectOfType<CraftingsList>().allItemsToCraft;

            foreach(var currentList in numbOfList)
            {
                
            }
            */
        }
    }
}
