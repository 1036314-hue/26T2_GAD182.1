using UnityEngine;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour
{
    [SerializeField]
    protected string itemName;

    [SerializeField] 
    protected Sprite sprite;
    [SerializeField]
    protected string itemDescription;
    [SerializeField]
    protected int itemAmount;
    [SerializeField]
    protected double saleValue;

    public Inventory inventory;

    private bool canPickUp;

    private void Start()
    {
        //Finding the inventory script
        // = GameObject.Find("Inventory").GetComponent<Inventory>();
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
            canPickUp = false;
            inventory.AddItem(itemName, sprite, itemDescription, itemAmount, saleValue);
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
