using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public string itemName;

    private bool pickUpAllowed;

    public int quantity;

    [SerializeField] private Sprite sprite;
    [TextArea]
    public string itemDescription;

    private InventoryManager InventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        InventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int leftOverItems = InventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            if (leftOverItems <= 0)
                pickUpAllowed = true;
            else
                quantity = leftOverItems;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
    }
}
