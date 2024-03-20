using System.Collections;
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

    private void Start(){
        rigidBody2D = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
       

        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                Vector3 targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(IsWalkable(targetPos)){

                
                 StartCoroutine(Move(targetPos));
                }
                // Set IsRunning parameter in the Animator
                Animator.SetBool("IsRunning", true);
            }
            else
            {
                // Set IsRunning parameter to false when not moving
                Animator.SetBool("IsRunning", false);
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            rigidBody2D.MovePosition(targetPos);
            //transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos; // Make sure to set the final position after the loop

        isMoving = false;
    }
    private bool IsWalkable(Vector3 targetPos)
    {
            if(Physics2D.OverlapCircle(targetPos,0.2f,solidObjectsLayer | interactableLayer) != null)
            {
                return false;
            }
            return true;
    }
}