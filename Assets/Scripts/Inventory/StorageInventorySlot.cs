using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class StorageInventorySlot : MonoBehaviour
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
        if (UIScreenManager.instance.CurrentUIScreen() == UIScreenType.StorageInventoryUI && EventSystem.current.currentSelectedGameObject == button.gameObject && item != null)
        {
            
            if (input.inventoryUse)
            {
                AddItemToPlayerInventory();
            }
        }

    }

    void AddItemToPlayerInventory()
    {
        PlayerInventory.instance.AddItem(item);
        //StorageInventory storageInventory = PlayerInventory.instance.GetComponent<PlayerInteract>().focus.GetComponent<StorageInventory>();
        //storageInventory.RemoveItem(item);
    }

}
