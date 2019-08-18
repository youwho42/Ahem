using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageInteract : Interactable
{
    StorageInventory inventory;

    private void Start()
    {
        inventory = GetComponent<StorageInventory>();
    }

    public override void Interact()
    {
        Debug.Log("Calling Interact");
        if (!inventory.inventoryIsDisplayed)
        {
            base.Interact();
            PickUp();
            
        }
        
    }

    void PickUp()
    {
        inventory.DisplayStorageInventory();

    }
}
