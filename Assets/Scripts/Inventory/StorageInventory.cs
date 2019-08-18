using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageInventory : Inventory
{
    public bool inventoryIsDisplayed;

    public PlayerInput input;

    private void Start()
    {
        input = FindObjectOfType<PlayerInput>();
    }

    public void DisplayStorageInventory()
    {
        if (!inventoryIsDisplayed)
        {
            UIScreenManager.instance.DisplayScreen(UIScreenType.StorageInventoryUI);
            inventoryIsDisplayed = true;
            
        }
     
    }

    private void Update()
    {
        if (input.inventoryDisplay && inventoryIsDisplayed)
        {
            UIScreenManager.instance.HideScreens(UIScreenType.StorageInventoryUI);
            inventoryIsDisplayed = false;
        }
    }
}
