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
    public VisualTreeAsset[] UIs;

    private VisualElement LeftPanelControler;
    private VisualElement ChangePanel;
    
    private void ButtonHandler()
    {
       for(int i = 0; i < Inv.Q<VisualElement>("ChangePanel").childCount; i++)
       {
            int index = i;
            Button button = (Button)Inv.Q<VisualElement>("ChangePanel").ElementAt(i);
            button.clickable.clicked += () =>
            {
                Inv.Q<TabView>("LeftPanel").tabIndex = index;
            };
       };
    }

    private void Start()
    {
        Inv = GetComponent<UIDocument>().rootVisualElement;   
    }
}
