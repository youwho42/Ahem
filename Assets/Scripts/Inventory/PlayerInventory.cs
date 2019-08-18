using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Inventory
{
    public static PlayerInventory instance;
    public PlayerInput input;

    public int coins;
    public bool inventoryIsDisplayed;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (input.inventoryDisplay && !inventoryIsDisplayed && UIScreenManager.instance.CurrentUIScreen() == UIScreenType.None)
        {
            UIScreenManager.instance.DisplayScreen(UIScreenType.InventoryUI);
            inventoryIsDisplayed = true;
        }
        else if (input.inventoryDisplay && inventoryIsDisplayed)
        {
            UIScreenManager.instance.HideScreens(UIScreenType.InventoryUI);
            inventoryIsDisplayed = false; 
        }
    }
}
