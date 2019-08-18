using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;

        private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        else
        {
            instance = this;
        }
    }
    public delegate void OnEquipmentChanged(ItemEquipment newItem, ItemEquipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    public ItemEquipment[] currentEquipment;
    PlayerInput input;

    private void Start()
    {
        int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlots)).Length;
        currentEquipment = new ItemEquipment[numberOfSlots];
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (input.inventoryUnequipAllItem)
        {
            UnequipAll();
        }    
    }

    public void Equip(ItemEquipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        ItemEquipment oldItem = null;

        if(currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            PlayerInventory.instance.AddItem(oldItem);
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {
            ItemEquipment oldItem = currentEquipment[slotIndex];
            PlayerInventory.instance.AddItem(oldItem);

            currentEquipment[slotIndex] = null;
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }
}
