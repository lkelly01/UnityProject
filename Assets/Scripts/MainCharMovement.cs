using System.Collections;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Animator Animator; 

    private bool isMoving;
    private Vector2 input;
    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;

    private Rigidbody2D rigidBody2D;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void HandleUpdate()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                Vector3 targetPos = transform.position + new Vector3(input.x, input.y, 0f);

                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                    Animator.SetBool("IsRunning", true);
                }
            }
            else
            {
                Animator.SetBool("IsRunning", false);
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            rigidBody2D.MovePosition(newPosition);
            yield return null;
        }

        transform.position = targetPos; // Set the final position after the loop
        isMoving = false;

        // Call Interact() after the player has finished moving
        Interact();
    }

    void Interact()
    {
        // Calculate the interact position based on the player's facing direction
        Vector3 facingDir = new Vector3(input.x, input.y);
        Vector3 interactPos = transform.position + facingDir;

        // Perform the overlap circle check
        Collider2D collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);

        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        // Perform overlap circle check for both solid objects and interactable objects
        Collider2D collider = Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactableLayer);
        return (collider == null);
    }
        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("Item Picked Up");
            collision.gameObject.GetComponent<Item>().ItemPickedUp();
        }
    } 
}
