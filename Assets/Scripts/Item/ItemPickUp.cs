using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    public GameObject parent;
    private Button buttonPickUp;
    // Start is called before the first frame update
    void Start()
    {
        buttonPickUp = GameObject.FindGameObjectWithTag("PickUp").GetComponent<Button>();
    }


    void PickUp()
    {
        buttonPickUp.interactable = false;
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(parent);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            buttonPickUp.onClick.RemoveAllListeners();
            buttonPickUp.onClick.AddListener(PickUp);

            buttonPickUp.interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            buttonPickUp.onClick.RemoveListener(PickUp);
            buttonPickUp.interactable = false;
        }
    }
}
