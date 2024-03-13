using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using static UnityEditor.Progress;
using static UnityEngine.UI.Image;


public class playerEq : MonoBehaviour
{
    public TextMeshProUGUI infoSlot;
    public Transform grid;

    private GameObject EqItem;
    private bool EqOnOff = true;
    private int currentId = 0;

    public Canvas mainUI;
    
    public int allItems;

    private void Start()
    {
        mainUI.GetComponent<Canvas>().enabled = false;
    }

    private void Update()
    {
        EqItem = GameObject.FindGameObjectWithTag("UiItemTest");

        //pokazanie eq
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (EqOnOff) //1 naciœniêcie
            {
                gameObject.GetComponent<PlayerMovment>().canMove = false;
                Cursor.lockState = CursorLockMode.None;
                mainUI.GetComponent<Canvas>().enabled = true;
                addItems();
                EqOnOff = false;
            }
            else //2 naciœniêcie
            {
                gameObject.GetComponent<PlayerMovment>().canMove = true;
                Cursor.lockState = CursorLockMode.Locked;
                mainUI.GetComponent<Canvas>().enabled = false;
                deleteUI();
                EqOnOff = true;
            }
        }

    }

    private List<itemsClass> item = new List<itemsClass>();
    public List<itemsClass> BeforeList = new List<itemsClass>();

    public void addItems()
    {
        BeforeList.Clear();
        item = GetComponent<EqScipt>().item;
        allItems = 0;
        currentId = 0;

        //niepytaj sam niewiem co tu siê dzieje
        //z jakiegoœ powodu podczas zmiany zak³adanego przedmiotu
        //tworzy pust¹ kopiê co tworzy problemy
        //wiêc udwaj ¿e tego niema
        //dzia³a? dzia³a. :D
        itemsClass abc = item[0];
        try
        {
            foreach(var test in item)
            {
                abc = test;
                test.GetComponent<itemsClass>();
            }
        }
        catch { item.Remove(abc); }
        //

        foreach(var item in item)
        {
            item.GetComponent<itemsClass>().Id = currentId;
            currentId++;

        }

        foreach(var newObject in item)
        {
            GameObject eqItem;
            TextMeshProUGUI text;

            BeforeList.Add(newObject);

            var isStackable = false;
            var stackLimit = 0;
            var stacks = 0;
            var stackInfo = "";
            var newStack = 0;
            var ItWas = false;
            var test = 0;

            isStackable = newObject.GetComponent<itemsClass>().stack;
            stackLimit = newObject.GetComponent<itemsClass>().stackLimit;


            //show no stackable items
            if (!isStackable)
            {
                noStacable(newObject);

            }
            else //stacable items
            {
                //all items
                var numberOfItems = 0;
                foreach(var newItem in item)
                {
                    if(newItem.name == newObject.name)
                    {
                        numberOfItems++;
                    }
                }

                //was item before
                test = 0;
                foreach (var currentItem in BeforeList)
                {
                    if(currentItem.name == newObject.name)
                    {
                        test++;
                    }
                }
                if (test >= 2)
                {
                    ItWas = true;
                }

                //how many stacks have items
                if (numberOfItems > stackLimit)
                {
                    for(float i = 0; i < numberOfItems / stackLimit; i++)
                    {
                        stacks++;
                    }
                }
                //new stack
                newStack = numberOfItems - (stacks * stackLimit);
                stackInfo = " X"+newStack;

                //show items
                if (!ItWas)
                {
                    //full stacks
                    for (int i = 0; i < stacks; i++)
                    {
                        eqItem = Instantiate(EqItem, grid);
                        text = eqItem.GetComponentInChildren<TextMeshProUGUI>();
                        text.text = newObject.GetComponent<itemsClass>().name + " X" + stackLimit;
                        eqItem.name = newObject.name;

                        Component copy = eqItem.AddComponent(newObject.GetType());
                        System.Type type = newObject.GetType();
                        System.Reflection.FieldInfo[] fields = type.GetFields();
                        
                        foreach (System.Reflection.FieldInfo field in fields)
                        {
                            field.SetValue(copy, field.GetValue(newObject));
                        }
                        //eqItem.GetComponent<itemsClass>().Id = currentId;
                        //currentId++;
                        
                        allItems++;
                    }

                    //new stacks
                    if (newStack != 0)
                    {
                        eqItem = Instantiate(EqItem, grid);
                        text = eqItem.GetComponentInChildren<TextMeshProUGUI>();
                        text.text = newObject.GetComponent<itemsClass>().name + stackInfo;
                        eqItem.name = newObject.name;

                        Component copy = eqItem.AddComponent(newObject.GetType());
                        System.Type type = newObject.GetType();
                        System.Reflection.FieldInfo[] fields = type.GetFields();

                        foreach (System.Reflection.FieldInfo field in fields)
                        {
                            field.SetValue(copy, field.GetValue(newObject));
                        }
                        //eqItem.GetComponent<itemsClass>().Id = currentId;
                        //currentId++;
                        allItems++;
                    }
                }
            }
        }
    }

    //add no stacable
    public void noStacable(itemsClass newObject)
    {
        GameObject eqItem;
        TextMeshProUGUI text;
        eqItem = Instantiate(EqItem, grid);
        text = eqItem.GetComponentInChildren<TextMeshProUGUI>();
        text.text = newObject.GetComponent<itemsClass>().name;
        eqItem.name = newObject.name;

        Component copy = eqItem.AddComponent(newObject.GetType());
        System.Type type = newObject.GetType();
        System.Reflection.FieldInfo[] fields = type.GetFields();

        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(newObject));
        }
        //eqItem.GetComponent<itemsClass>().Id = currentId;
        //currentId++;
        allItems++;
    }

    //clear UI
    public void deleteUI()
    {
         GameObject[] obj = GameObject.FindGameObjectsWithTag("UiItemTest");

        for (int i = 1; i < obj.Length; i++)
        {
            Destroy(obj[i]);
        }
    }

    //private TextMeshProUGUI limit;
    public void showInfo()
    {
        infoSlot.text = "Eq is full";
    }
}