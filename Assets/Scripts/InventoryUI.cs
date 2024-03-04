using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI[] itemTexts; // Array of Text elements to display item counts
    public GameObject[] itemImages; // Array of Image elements to display item icons
    public InteractableObject.InteractableType[] itemTypes; // Array of InteractableTypes corresponding to items
    
    public static InventoryUI instance;
    public void InventoryAdding()
    {
        if (InventoryManager.Instance.HasItem(InteractableObject.InteractableType.Key))
        {
            itemImages[0].gameObject.SetActive(true);
            itemTexts[0].gameObject.SetActive(true);
        }
        if (InventoryManager.Instance.HasItem(InteractableObject.InteractableType.Coin))
        {
            itemImages[1].gameObject.SetActive(true);
            itemTexts[1].gameObject.SetActive(true);
        }
        if (InventoryManager.Instance.HasItem(InteractableObject.InteractableType.Potion))
        {
            itemImages[2].gameObject.SetActive(true);
            itemTexts[2].gameObject.SetActive(true);
        }
    }

    public void SetInventoryNums()
    {
        itemTexts[0].text = InventoryManager.Instance.GetItemCount(InteractableObject.InteractableType.Key).ToString();
        itemTexts[1].text = InventoryManager.Instance.GetItemCount(InteractableObject.InteractableType.Coin).ToString();
        itemTexts[2].text = InventoryManager.Instance.GetItemCount(InteractableObject.InteractableType.Potion).ToString();
    }

    public void RemoveInventory()
    {
        if (!InventoryManager.Instance.HasItem(InteractableObject.InteractableType.Key))
        {
            itemImages[0].gameObject.SetActive(false);
            itemTexts[0].gameObject.SetActive(false);
        }
        if (!InventoryManager.Instance.HasItem(InteractableObject.InteractableType.Coin))
        {
            itemImages[1].gameObject.SetActive(false);
            itemTexts[1].gameObject.SetActive(false);
        }
        if (!InventoryManager.Instance.HasItem(InteractableObject.InteractableType.Potion))
        {
            itemImages[2].gameObject.SetActive(false);
            itemTexts[2].gameObject.SetActive(false);
        }
    }



    private void Awake()
    {
        // Singleton
        if (instance != null)
        {
            Debug.LogError("There is more than one Instance");
        }

        instance = this;
    }
}

