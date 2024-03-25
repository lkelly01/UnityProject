using UnityEngine;

public class ChestOpener : MonoBehaviour, Interactable
{
    public GameObject chest;

    void Start()
    {
        // Ensure the chest is initially inactive
        chest.SetActive(false);
    }

    // Implement the Interact method from the Interactable interface
    public void Interact()
    {
        // Open the chest when interacted with
        chest.SetActive(true);
    }

    // This method is called when a Collider2D enters the trigger area
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            
            Debug.Log("Press 'E' to open the chest");
        }
    }

    // This method is called when a Collider2D exits the trigger area
    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            
        }
    }
}
