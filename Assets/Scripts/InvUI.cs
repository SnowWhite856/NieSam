using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InvUI : MonoBehaviour
{
    public UIDocument Document;

    [Header("Left panel")]
    public VisualTreeAsset Equipment;
    public VisualTreeAsset Potion;
    private VisualElement EquipmentVisual;
    private VisualElement PotionVisual;

    [Header("Keybind")]
    public KeyCode OpenInv;

    public enum Active
    {
        Equipment,
    }

    void Setup()
    {
        EquipmentVisual = Equipment.CloneTree().Q<VisualElement>("Component");
        //PotionVisual = Potion.CloneTree().Q<VisualElement>("Component");
    }

    void Start()
    {
        Debug.Log(OpenInv);
        Document.gameObject.SetActive(false);
        Setup();
        Debug.Log(EquipmentVisual);
        Document.rootVisualElement.Q<VisualElement>("LeftPanel").Add(EquipmentVisual);
    }

    void Update()
    {
        if(Input.GetKeyDown(OpenInv))
        {
            Document.gameObject.SetActive(!Document.gameObject.activeSelf);
        }
    }
}
