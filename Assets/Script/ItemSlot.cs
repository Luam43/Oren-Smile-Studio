using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //ITEM DATA//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;

    [SerializeField] private int maxNumberOfItems;

    //ITEM SLOT//
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    //ITEM DESK SLOT//
    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager InventoryManager;

    void Start()
    {
        InventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }



    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {

        if (isFull)
            return quantity;

        
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        this.itemDescription = itemDescription;

        this.quantity += quantity;
        if(this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;
        

            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }

        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        if (thisItemSelected)
        {
            InventoryManager.UseItem(itemName);
            this.quantity -= 1;
            quantityText.text = this.quantity.ToString();
            if(this.quantity<= 0)
                EmptySlot();
        }
            


        InventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;
        if(itemDescriptionImage.sprite == null)
            itemDescriptionImage.sprite = emptySprite;
    }

    public void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = emptySprite;

        ItemDescriptionNameText.text = "";
        ItemDescriptionText.text = "";
        itemDescriptionImage.sprite = emptySprite;

    }

    public void OnRightClick()
    {

    }

}
