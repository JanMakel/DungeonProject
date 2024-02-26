using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
     public enum InteractableType { Key, Coin, Chest, Potion}

    [SerializeField] private InteractableType type;

    public int amount;

    public InteractableType Type { get { return type; } }


    private bool canInteract = false;

    public int Amount { get { return amount; } }

    private InventoryManager inventory;

    [SerializeField] private InteractableType chestContent;
    public int chestAmount;


    private void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
        if (inventory == null)
        {
            Debug.LogError("InventoryManager not found in the scene!");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && type == InteractableType.Chest)
        {
            canInteract = true;
            if(Input.GetKeyDown(KeyCode.E) && inventory != null && inventory.HasItem(InteractableType.Key)) 
            {
                inventory.AddItem(chestContent, chestAmount);
                inventory.RemoveItem(InteractableType.Key, 1);
            }
            else
            {
                Debug.Log("You need a key to open this chest");
            }
        }
        if (collision.CompareTag("Player") && !canInteract)
        {
            // Get the InventoryManager component
            InventoryManager inventoryManager = collision.GetComponent<InventoryManager>();
            if (inventoryManager != null)
            {
                // Add the item to the inventory
                inventoryManager.AddItem(type, amount);
                // Destroy the object
                Destroy(gameObject);
            }
        }

        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    }
   

