using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class StorageInventoryUI : MonoBehaviour
{
    public Transform playerItemsParent;
    public Transform storageItemsParent;



    PlayerInventory playerInventory;
    public StorageInventory storageInventory;
    public TextMeshProUGUI coinText;

    InventorySlot[] playerSlots;
    StorageInventorySlot[] storageSlots;


    private void Awake()
    {
        playerInventory = PlayerInventory.instance;
        playerInventory.onItemChangedCallback += UpdateUI;

        storageSlots = storageItemsParent.GetComponentsInChildren<StorageInventorySlot>();

        playerSlots = playerItemsParent.GetComponentsInChildren<InventorySlot>();


    }
    private void OnEnable()
    {
        if (storageInventory == null)
        {
            GetStorageInventory();
            UpdateStorageUI();
        }
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
        for (int i = 0; i < playerSlots.Length; i++)
        {
            if (i < playerInventory.inventory.Count)
            {
                playerSlots[i].AddItem(playerInventory.inventory[i]);
            }
            else
            {
                playerSlots[i].ClearSlot();
            }

        }
        coinText.text = playerInventory.coins.ToString();
    }

    void GetStorageInventory()
    {
        try
        {
            storageInventory = playerInventory.GetComponent<PlayerInteract>().focus.GetComponent<StorageInventory>();
            storageInventory.onItemChangedCallback += UpdateStorageUI;
            
        }
        catch
        {
            return;
        }
    }

    
    void UpdateStorageUI()
    {
        if(storageInventory != null)
        {
            for (int i = 0; i < storageSlots.Length; i++)
            {
                if (i < storageInventory.inventory.Count)
                {
                    storageSlots[i].AddItem(storageInventory.inventory[i]);
                }
                else
                {
                    storageSlots[i].ClearSlot();
                }
            }
        }
        
    }
    
}
