using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public TextMeshProUGUI redPotionText;
    private int redPotionCount;
    public GameObject InventoryMenu;
    private bool menuActivated;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    public void AddItem(string itemName, int quantity)
    {
        Debug.Log("itemName = " + itemName + ", quantity = " + quantity);
        if(itemName=="Red Potion"){
            redPotionCount++;
            redPotionText.SetText($"X {redPotionCount}");
        }
    }    
}
