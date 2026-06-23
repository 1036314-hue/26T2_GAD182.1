using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject itemInspectorImageObject = GameObject.Find("ItemInspectorImage");
        itemInspectorImage = itemInspectorImageObject.GetComponent<Image>();

        GameObject itemInspectorDescriptionObject = GameObject.Find("ItemInspectorDescription");
        itemInspectorDescription = itemInspectorDescriptionObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        itemCount += -1;
        itemCounter.text = itemCount.ToString();
        if (itemCount <= 0)
        {
            //FIND A WAY TO REMOVE THIS INSTANCE OF ITEMSPACE SCRIPT FROM ITEMSPACE IN INVENTORY
            Destroy(gameObject);
        }
    }

    public void DisplayInInspector()
    {
        itemInspectorImage.sprite = itemSprite;
        itemInspectorDescription.text = itemDescription.ToString();
    }
}
