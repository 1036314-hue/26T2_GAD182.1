using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryMenu;

    public GameObject inventorySlot;

    public GameObject inventoryItemSection;

    private bool itemAdded;

    public List<ItemSpace> itemSpace = new List<ItemSpace>();
    
    void Update()
    {
        //Checking if inventory isn't currently active and activating it
        if (!inventoryMenu.activeSelf && Keyboard.current.iKey.wasPressedThisFrame)
        {
            inventoryMenu.SetActive(true);
        }
        //Checking if inventory is currently active and deactivating it
        else if (inventoryMenu.activeSelf && Keyboard.current.iKey.wasPressedThisFrame)
        {
            inventoryMenu.SetActive(false);
        }
    }

    public void AddItem(string itemName, Sprite sprite, string itemDescription, int itemAmount, double saleValue)
    {
        Debug.Log(itemName + " " + sprite + " " + itemDescription + " " + itemAmount + " " + saleValue);

        //Checking if we already have the specific Item in inventory
        for (int i = 0; i < itemSpace.Count; i++)
        {
            if (itemSpace[i].containsItem && itemName == itemSpace[i].itemName)
            {
                itemSpace[i].AddItem(itemName, sprite, itemDescription, itemAmount, saleValue);
                itemAdded = true;
                break;
            }
        }
        //If no specific item already create new inventory slot with item assigned
        if (!itemAdded)
        {
            Instantiate(inventorySlot, inventoryItemSection.transform);
            itemSpace.Add(inventorySlot.GetComponent<ItemSpace>());
            itemSpace[itemSpace.Count].AddItem(itemName, sprite, itemDescription, itemAmount, saleValue);
        }


    }
}
