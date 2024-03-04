using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

public class TabViewSelector : MonoBehaviour
{
    private VisualElement Inv;
    
    private void ButtonHandler()
    {
       for(int i = 0; i < Inv.Q<VisualElement>("ChangePanel").childCount; i++)
       {
            int index = i;
            Button button = (Button)Inv.Q<VisualElement>("ChangePanel").ElementAt(i);
            button.clickable.clicked += () =>
            {
                Debug.Log("INV index: " + index);
                Inv.Q<TabView>("LeftPanel").selectedTabIndex = index;
            };
       };
    }

    private void Start()
    {
        Inv = GetComponent<UIDocument>().rootVisualElement;
        ButtonHandler();
    }
}
