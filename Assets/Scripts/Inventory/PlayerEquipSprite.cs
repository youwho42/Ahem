using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipSprite : MonoBehaviour
{
    EquipmentManager equipment;

    SpriteRenderer equipmentSprite;

    public EquipmentSlots slot;
    public EquipmentParts part;

    private void Start()
    {
        equipment = EquipmentManager.instance;
        equipment.onEquipmentChanged += UpdateEquipmentSprite;
        equipmentSprite = GetComponent<SpriteRenderer>();
    }

    void UpdateEquipmentSprite(ItemEquipment newItem, ItemEquipment oldItem)
    {
        if(newItem != null)
        {
            if (newItem.equipSlot == slot)
            {
                if(newItem.parts != null)
                {
                    for (int i = 0; i < newItem.parts.Length; i++)
                    {
                        if (newItem.parts[i].part == part)
                        {
                            equipmentSprite.sprite = newItem.parts[i].image;
                            return;
                        }
                    }
                }
                
                
                
            }
            return;

        }
        if(oldItem != null)
        {
            if(oldItem.equipSlot == slot)
            {
                equipmentSprite.sprite = null;
            }
            return;
        }
        
        
        
        
    }
}


