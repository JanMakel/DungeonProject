using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Dictionary<InteractableObject.InteractableType, int> inventory = new Dictionary<InteractableObject.InteractableType, int>();
    
    public static InventoryManager Instance;

    /// <summary>
    /// This function takes type of object and amount of the object to add it to the dictionary creating a Key, if the dictionary already
    /// has the key jus add the amount of that key it needs
    /// </summary>
    /// <param name="type">Type of the object</param>
    /// <param name="amount">Amount of objects added</param>
    public void AddItem(InteractableObject.InteractableType type, int amount)
    {
        if (inventory.ContainsKey(type))
        {
            inventory[type] += amount;
            InventoryUI.instance.SetInventoryNums();
        }
        else
        {
            inventory.Add(type, amount);
            Debug.Log($"{type}, {amount}");
            InventoryUI.instance.InventoryAdding();
            InventoryUI.instance.SetInventoryNums();
        }
    }
    /// <summary>
    /// This function removes a amount of objects from the inventory, if the type of the inventory has 0 amount, this function removes the key from the 
    /// dictionary
    /// </summary>
    /// <param name="type">Type of object</param>
    /// <param name="amount">Amount of objects removed</param>
    public void RemoveItem(InteractableObject.InteractableType type, int amount)
    {
        if (inventory.ContainsKey(type))
        {
            inventory[type] -= amount;
            if (inventory[type] <= 0)
            {
                inventory.Remove(type);
                InventoryUI.instance.RemoveInventory();
                InventoryUI.instance.SetInventoryNums();
            }
            InventoryUI.instance.SetInventoryNums();
        }
    }
    /// <summary>
    /// This function checks if the inventory has or not the item requested
    /// </summary>
    /// <param name="type">Type of itme requested</param>
    /// <returns>If Has or not the itme requested</returns>
    public bool HasItem(InteractableObject.InteractableType type)
    {
        return inventory.ContainsKey(type);
    }
    /// <summary>
    /// This funtion returns the the amount of itmes of the object asked the inventory has.
    /// </summary>
    /// <param name="type">The type of object requested</param>
    /// <returns>How many of that items the inventory has</returns>
    public int GetItemCount(InteractableObject.InteractableType type)
    {
        return inventory.ContainsKey(type) ? inventory[type] : 0;
    }

    private void Awake()
    {
        // Singleton
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance");
        }

        Instance = this;
    }
}
