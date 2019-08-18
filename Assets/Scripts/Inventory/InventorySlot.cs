using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Image amountHolder;
    public TextMeshProUGUI amountText;
    Item item;

    Button button;
    PlayerInput input;

    private void Awake()
    {
        input = FindObjectOfType<PlayerInput>();
        button = GetComponent<Button>();

    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        amountHolder.gameObject.SetActive(true);
        if (item.canStack)
        {
            amountText.text = item.numberHeld.ToString();
        }
        else
        {
            amountText.text = (item.numberHeld / item.numberHeld).ToString();
        }

        icon.sprite = item.icon;
        icon.enabled = true;
        button.interactable = true;


    }

    public void ClearSlot()
    {
        item = null;
        amountText.text = "";
        amountHolder.gameObject.SetActive(false);
        icon.sprite = null;
        icon.enabled = false;
        button.interactable = false;
    }



    private void Update()
    {
        if (UIScreenManager.instance.CurrentUIScreen() == UIScreenType.InventoryUI && EventSystem.current.currentSelectedGameObject == button.gameObject && item != null)
        {
            if (input.inventoryRemove)
            {
                DropItemFromInventory();
            }
            if (input.inventoryUse)
            {

                item.UseItem();
                RemoveItemFromInventory();

            }
        }

    }

    public void RemoveItemFromInventory()
    {
        PlayerInventory.instance.RemoveItem(item);
    }

    public void DropItemFromInventory()
    {
        PlayerInventory.instance.DropItem(item);
    }
}
