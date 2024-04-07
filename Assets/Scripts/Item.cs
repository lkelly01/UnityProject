using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity;


   

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name); // Debug log to check collision

        if (collision.gameObject.CompareTag("Player")) // Check for player collision
        {
            Debug.Log("Item picked up by player: " + itemName); // Debug log for item pickup
           
        }
    }
    public void ItemPickedUp(){
         inventoryManager.AddItem(itemName, quantity); // Call the InventoryManager method
            Destroy(gameObject); // Destroy the item object
    }
}

