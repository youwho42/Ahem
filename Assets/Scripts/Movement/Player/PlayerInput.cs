using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 directionalInput { get; private set; }

    public bool jumpInput { get; private set; }
    public bool jumpInputOver { get; private set; }

    public bool isCrouching { get; private set; }
    public bool isRunning { get; private set; }

    public bool interactInput { get; private set; }

    public bool inventoryDisplay { get; private set; }

    public bool inventoryRemove { get; private set; }
    public bool inventoryUse { get; private set; }
    public Vector2 inventoryNavigationInput { get; private set; }

    public bool inventoryUnequipItem { get; private set; }
    public bool inventoryUnequipAllItem { get; private set; }

    PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = PlayerInventory.instance;
    }

    private void Update()
    {
        if (UIScreenManager.instance.CurrentUIScreen() == UIScreenType.None)
        {
            directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            jumpInput = Input.GetButtonDown("Jump");
            jumpInputOver = Input.GetButtonUp("Jump");

            interactInput = Input.GetButtonDown("Fire1");
            isCrouching = Input.GetButtonDown("Crouch");
            isRunning = Input.GetButtonDown("Run");

        }
        else
        {
            interactInput = false;
            inventoryNavigationInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            inventoryUse = Input.GetButtonDown("Fire2");
            inventoryRemove = Input.GetButtonDown("Fire1");
            inventoryUnequipItem = Input.GetButtonDown("Fire3");
            inventoryUnequipAllItem = Input.GetButtonDown("Fire4");
        }
        

        inventoryDisplay = Input.GetButtonDown("Inventory");

        
    }
}
