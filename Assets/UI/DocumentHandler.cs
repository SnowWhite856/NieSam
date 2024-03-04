using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DocumentHandler : MonoBehaviour
{
    [Header("Documents to handle")]
    public VisualTreeAsset InventoryDocument;
    public VisualTreeAsset GeneralUIDocument;

    [Header("Shortcuts")]
    public KeyCode Inv;

    private UIDocument UIComponent;

    [Header("State")]

    public UIState CurrentState;

    public enum UIState
    {
        GeneralUI,
        Inv,
        SkillTree
    }

    private void Start()
    {
        UIComponent = GetComponent<UIDocument>();
        CurrentState = UIState.GeneralUI;
    }

    private void Update()
    {
        if (Input.GetKeyDown(Inv))
        {
            Debug.Log(CurrentState);
        }
    }
}
