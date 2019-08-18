using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public Transform equipItemsParent;

    PlayerInventory inventory;
    EquipmentManager equipment;
    public TextMeshProUGUI coinText;

    InventorySlot[] slots;
    EquipmentSlot[] equipSlots;

    private void Awake()
    {
        inventory = PlayerInventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        equipment = EquipmentManager.instance;
        equipment.onEquipmentChanged += UpdateEquipmentUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        equipSlots = equipItemsParent.GetComponentsInChildren<EquipmentSlot>();
    }

    

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
          
        }
        
    }
    

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.inventory.Count)
            {
                slots[i].AddItem(inventory.inventory[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
            
        }
        coinText.text = inventory.coins.ToString();
    }
    void UpdateEquipmentUI(ItemEquipment newItem, ItemEquipment oldItem)
    {
        if (newItem != null)
        {
            for (int i = 0; i < equipSlots.Length; i++)
            {
            
            
                if (i == (int)newItem.equipSlot)
                {
                    equipSlots[i].AddItem(newItem);
                }
                
            }
        }
        else
        {
            equipSlots[(int)oldItem.equipSlot].ClearSlot();
        }
    }
}
