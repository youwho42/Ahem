using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class EquipmentSlot : MonoBehaviour
{
    public Image icon;
    ItemEquipment item;
    Button button;
    PlayerInput input;

    private void Start()
    {
        input = FindObjectOfType<PlayerInput>();
        button = GetComponent<Button>();

    }

    private void Update()
    {
        if (PlayerInventory.instance.inventoryIsDisplayed && EventSystem.current.currentSelectedGameObject == button.gameObject && item != null)
        {
            if (input.inventoryUnequipItem)
            {
                EquipmentManager.instance.Unequip((int)item.equipSlot);
            }
            
        }

    }

    public void AddItem(ItemEquipment newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        button.interactable = true;


    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        button.interactable = false;
    }

}