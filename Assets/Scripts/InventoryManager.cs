using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Dictionary<InteractableObject.InteractableType, int> inventory = new Dictionary<InteractableObject.InteractableType, int>();

    public static InventoryManager Instance;
    public void AddItem(InteractableObject.InteractableType type, int amount)
    {
        if (inventory.ContainsKey(type))
        {
            inventory[type] += amount;
            
        }
        else
        {
            inventory.Add(type, amount);
            Debug.Log($"{type}, {amount}");
        }
    }

    public void RemoveItem(InteractableObject.InteractableType type, int amount)
    {
        if (inventory.ContainsKey(type))
        {
            inventory[type] -= amount;
            if (inventory[type] <= 0)
            {
                inventory.Remove(type);
            }
        }
    }

    public bool HasItem(InteractableObject.InteractableType type)
    {
        return inventory.ContainsKey(type);
    }

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
