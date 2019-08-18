using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Consumable Item")]
public class ItemConsumable : Item
{
    public ConsumableType consumableType;
    public int consumableEffect;

    public override void UseItem()
    {
        base.UseItem();
        
    }

}

public enum ConsumableType
{
    Health,
    Buff
}
