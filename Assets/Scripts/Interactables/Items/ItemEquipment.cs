using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Equipment Item")]
public class ItemEquipment : Item
{
    public EquipmentSlots equipSlot;
    public EquipmentPart[] parts;

    public int armorModifier;
    public int damageModifier;

   

    public override void UseItem()
    {
        base.UseItem();
        EquipmentManager.instance.Equip(this);
        
    }

    [Serializable]
    public struct EquipmentPart
    {
        public EquipmentParts part;
        public Sprite image;
    }


}


