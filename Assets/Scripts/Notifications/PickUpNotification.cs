using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpNotification : MonoBehaviour
{

    ItemPickup item;

    private void Start()
    {
        item = GetComponent<ItemPickup>();
    }

    void SendNotification()
    {
        NotificationManager.instance.SetNewNotification(item.item.itemName);
    }
}
