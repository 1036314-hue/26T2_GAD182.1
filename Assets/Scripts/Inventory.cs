using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryMenu;

    public GameObject inventorySlot;

    public GameObject inventoryItemSection;

    public List<ItemSpace> itemSpace = new List<ItemSpace>();
    
    void Update()
    {
        //Checking if inventory isn't currently active and activating it
        if (!inventoryMenu.activeSelf && Keyboard.current.iKey.wasPressedThisFrame)
        {
            inventoryMenu.SetActive(true);
            //Turns off the Cursor lock in the movement Script so we can click around the menu
            Cursor.lockState = CursorLockMode.None;
        }
        //Checking if inventory is currently active and deactivating it
        else if (inventoryMenu.activeSelf && Keyboard.current.iKey.wasPressedThisFrame)
        {
            inventoryMenu.SetActive(false);
            //Turns on the Cursor lock so our mouse doesnt go off the screen
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void AddItem(string itemName, Sprite sprite, string itemDescription, int itemAmount, double saleValue)
    {
        Debug.Log(itemName + " " + sprite + " " + itemDescription + " " + itemAmount + " " + saleValue);
        bool itemAdded = false;

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
            GameObject slotClone = Instantiate(inventorySlot, inventoryItemSection.transform);
            itemSpace.Add(slotClone.GetComponent<ItemSpace>());
            itemSpace[itemSpace.Count - 1].AddItem(itemName, sprite, itemDescription, itemAmount, saleValue);
        }
    }
    
}
