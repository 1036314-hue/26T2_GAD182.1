using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ItemSpace : MonoBehaviour
{
    public string itemName;
    public Sprite itemSprite;
    string itemDescription;
    public double saleValue;
    public int itemCount;
    public bool containsItem;

    private TextMeshProUGUI itemCounter;

    private Image itemImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    }
}
