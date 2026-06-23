using UnityEngine;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour
{
    protected string itemName;

    [SerializeField] 
    protected Sprite sprite;

    protected string itemDescription;

    protected int itemAmount;

    protected double saleValue;

    private Inventory inventory;

    private bool canPickUp;

    private void Start()
    {
        //Finding the inventory script
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    //Set the item to be pickupable inside of range
    private void OnTriggerEnter(Collider other)
    {
        canPickUp = true;
    }

    private void Update()
    {
        if (canPickUp && Keyboard.current.eKey.wasPressedThisFrame)
        {
            inventory.AddItem(itemName, sprite, itemDescription, itemAmount, saleValue);
            canPickUp=false;
            Destroy(gameObject);
        }
    }

    //Set the item to no longer be pickupable outside of range
    private void OnTriggerExit(Collider other)
    {
        canPickUp = false;
    }

    void PickUp()
    {

    }

    void UseItem()
    {

    }

    void DiscardItem()
    {

    }

    void SellItem()
    {

    }


}
