using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        PlayerInventory.instance.coins += item.worth;
        NotificationManager.instance.SetNewNotification("" + item.worth.ToString() + " moons");
        Destroy(gameObject);
    }
}
