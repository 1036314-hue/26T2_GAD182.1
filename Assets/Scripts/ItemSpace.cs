using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
public class ItemSpace : MonoBehaviour
{
    public string itemName;
    public Sprite itemSprite;
    string itemDescription;
    public double saleValue;
    public int itemCount;
    public bool containsItem;

    [SerializeField]
    private TextMeshProUGUI itemCounter;

    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private Image itemInspectorImage;

    [SerializeField]
    private TextMeshProUGUI itemInspectorDescription;

    [SerializeField]
    private Inventory inventoryScript;

    [SerializeField]
    private Button removeButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject itemInspectorImageObject = GameObject.Find("ItemInspectorImage");
        itemInspectorImage = itemInspectorImageObject.GetComponent<Image>();

        GameObject itemInspectorDescriptionObject = GameObject.Find("ItemInspectorDescription");
        itemInspectorDescription = itemInspectorDescriptionObject.GetComponent<TextMeshProUGUI>();

        GameObject inventoryGameObject = GameObject.Find("Inventory");
        inventoryScript = inventoryGameObject.GetComponent<Inventory>();

        GameObject removeButtonGameObject = GameObject.Find("Remove Item");
        removeButton = removeButtonGameObject.GetComponent<Button>();
    }

    
    

    public void AddItem(string itemName, Sprite sprite, string itemDescription, int itemAmount, double saleValue)
    {
        //this used to differenciate variables being recieved from variables this script has
        this.itemName = itemName;
        itemSprite = sprite;
        this.itemDescription = itemDescription;
        this.itemCount += itemAmount;
        this.saleValue = saleValue;
 
        containsItem = true;

        //Changing visuals on the screen for items
        //(String)itemCount doesn't work but itemCount.ToString does
        itemCounter.text = itemCount.ToString();
        itemImage.sprite = itemSprite; 
    }

    public void RemoveItem()
    {
            itemCount -= 1;
        if (itemCount <= 0)
        {
            inventoryScript.RemoveItemSpace(inventoryScript.GetItemSpaceNumber(itemName));
            Destroy(gameObject);
        }
    }

    public void UseItem()
    {
        //Effect Happens here then

        RemoveItem();
    }

    public void SellItem()
    {
        //Effect Happens here then

        RemoveItem();
    }

    public void DisplayInInspector()
    {
        itemInspectorImage.sprite = itemSprite;
        itemInspectorDescription.text = itemDescription.ToString();
        removeButton.onClick.RemoveAllListeners();
        removeButton.onClick.AddListener(RemoveItem);

    }

 
}
