using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this class will be built from physicsobject, and contains the sprite - and speed variables.  It also calculates its own velocity.

public class PlayerPlatformerController : PhysicsObject
{
    //max player move speed and jump speed.
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public float chargeSpeed;
    public Vector2 direction;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Slider slider;
    public SkillDirection skillDirection;
    public Rigidbody2D rbody2d;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }   

    //a velocity grabber of some sort - lets us calculate if player is going too fast, and stop it.
    public override void ComputeVelocity()
    {
        float jumpMultiplier = 5f;

        Vector2 move = new Vector2(0, 0);
        move.x = Input.GetAxis("Horizontal");

        var mouseCoordinates = skillDirection.mouseCoordinates;
        float directionX = ((skillDirection.mouseCoordinates.x) - transform.position.x);
        float directionY = ((skillDirection.mouseCoordinates.y) - transform.position.y);

        if (Input.GetMouseButtonUp(0) && isGrounded)  //JUMP, this now works... WOO!
        {
            velocity = new Vector2(directionX, directionY);
            velocity.Normalize();
            velocity = velocity * jumpMultiplier * slider.value;
            rb2d.AddForce(velocity, ForceMode2D.Impulse);
            print(velocity.x + "\n" + velocity.y);
        }

        // THE ANIMATION ZONE!!!!!
        if (Input.GetKeyDown(KeyCode.D))  //make the little dude face the correct way if you press a button - not based on movement anymore because it fucking sucks.
        {spriteRenderer.flipX = false;}
        else if (Input.GetKeyDown(KeyCode.A))
        {spriteRenderer.flipX = true;}

        animator.SetBool("isGrounded", isGrounded);        //jumping animation bullshit - apply grounded bool to our animation variable.
        animator.SetFloat("Speed", Mathf.Abs(velocity.x) / maxSpeed);   //Apply speed to our animation variable
        targetVelocity = move * maxSpeed;
    }
}