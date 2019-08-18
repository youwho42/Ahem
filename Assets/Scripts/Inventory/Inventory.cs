using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> inventory = new List<Item>();

    public int inventorySpace = 40;

    public bool AddItem(Item item)
    {
        
        if (!inventory.Contains(item))
        {
            if (inventory.Count < inventorySpace)
            {
                inventory.Add(item);
                int index = inventory.IndexOf(item);
                inventory[index].numberHeld = 1;
                if(onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                
                return true;
            }
            return false;

        }
        else
        {
            if (!item.canStack)
            {
                if (inventory.Count < inventorySpace)
                {
                    inventory.Add(item);
                    int index = inventory.IndexOf(item);
                    inventory[index].numberHeld ++;
                    if (onItemChangedCallback != null)
                    {
                        onItemChangedCallback.Invoke();
                    }

                    return true;
                }
                return false;
            }
            else
            {
                int index = inventory.IndexOf(item);
                inventory[index].numberHeld++;
                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                return true;
            }
            
        }
          
        
    }
    public void RemoveItem(Item item)
    {
        //Debug.Log("removing");
        int index = inventory.IndexOf(item);
        if(inventory[index].numberHeld > 1)
        {
            inventory[index].numberHeld--;
            if (!item.canStack)
            {
                inventory.Remove(item);
            }
        }
        else
        {
            item.numberHeld = 0;
            inventory.Remove(item);
        }
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

    }
    public void DropItem(Item item)
    {
        Instantiate(item.prefab, transform.position, Quaternion.identity);
        RemoveItem(item);
    }
}
