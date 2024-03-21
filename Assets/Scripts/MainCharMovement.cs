using System.Collections;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Animator Animator; // Ensure this matches the variable name in your script

    private bool isMoving;
    private Vector2 input;
    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;

    private Rigidbody2D rigidBody2D;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // Instead of accessing "moveX" and "moveY", you can directly use input.x and input.y
            var facingDir = new Vector3(input.x, input.y);

            if (input != Vector2.zero)
            {
                Vector3 targetPos = transform.position + new Vector3(input.x, input.y, 0f);

                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                    // Set IsRunning parameter in the Animator
                    Animator.SetBool("IsRunning", true);
                }
            }
            else
            {
                // Set IsRunning parameter to false when not moving
                Animator.SetBool("IsRunning", false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
            Interact();
    }

    void Interact()
    {
        var facingDir = new Vector3(input.x, input.y);
        var interactPos = transform.position + facingDir;
        // Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);

        if (collider != null)
        {
            Debug.Log("there is an NPC here! ");
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

        transform.position = targetPos; // Make sure to set the final position after the loop

        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        Collider2D collider = Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactableLayer);
        return (collider == null);
    }
}
