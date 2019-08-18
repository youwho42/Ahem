using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Items/Generic Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;
    public bool canStack;
    public int numberHeld;
    public int worth;
    public GameObject prefab;

    public virtual void UseItem()
    {
        //Debug.Log("Using Item!");
    }

    public virtual void RemoveFromInventory()
    {
        PlayerInventory.instance.RemoveItem(this);
    }
}
