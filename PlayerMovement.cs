using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    public AudioSource SFX;
    
    public KeyCode pressUp;
    public KeyCode pressDown;
    public KeyCode pressLeft;
    public KeyCode pressRight;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pressUp) || Input.GetKeyDown(pressDown) || Input.GetKeyDown(pressLeft) || Input.GetKeyDown(pressRight))
        {
            SFX.Play();
        }

        if (Input.GetKeyUp(pressUp) || Input.GetKeyUp(pressDown) || Input.GetKeyUp(pressLeft) || Input.GetKeyUp(pressRight))
        {
            SFX.Stop(); 
        }



        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(Input.GetAxisRaw("Horizontal")==1 || Input.GetAxisRaw("Horizontal")==-1 || Input.GetAxisRaw("Vertical")==1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}


