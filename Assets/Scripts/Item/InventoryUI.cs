using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsparent;
    public GameObject inventoryUI;
    //implement crafting 
    Inventory inventory;
    InventorySlot[] slots;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;
        slots = itemsparent.GetComponentsInChildren<InventorySlot>();
    }
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
    public void ClickInventoryButton()
    {
        //make for crafting
        if (inventoryUI.activeSelf)
        {
            inventoryUI.SetActive(false);
        }
        else
        {
            UpdateUI();
            inventoryUI.SetActive(true);
        }
    }
}