using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{

	public Item item;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        bool wasAddedToInventory = PlayerInventory.instance.AddItem(item);
        if (wasAddedToInventory)
        {
            NotificationManager.instance.SetNewNotification(item.itemName);
            Destroy(gameObject);
        }
        
    }
}
