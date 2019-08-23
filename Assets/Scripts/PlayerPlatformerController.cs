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
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Slider slider;

    void Awake()
    {
        //grab the spriterenderer, and apply the animator, even if they won't do shit for a bit.
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    //a velocity grabber of some sort - lets us calculate if player is going too fast, and stop it.
    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");

        // ChargeAim()  //REAL JUMP
        
        if (Input.GetMouseButtonUp(0) && isGrounded)  //TEMP JUMP, this is just to make me happy for a short period of time.
        {
            //set 2d velocity, targeting current mouse location.
            velocity.x = slider.value * 10;  //FOR NEXT TIME - Why the hell isn't this working?
            velocity.y = slider.value * 10;
        }

        //since we're using sprites, if you're moving backwards - horizontal flip the sprite.
        bool flipSprite = (spriteRenderer.flipX ? (move.x >= 0.01f) : (move.x <= 0.01f));

        if (flipSprite)  //if moving -x, flip that sprite
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //jumping animation bullshit
        animator.SetBool("grounded", isGrounded);  //this will be more important if we can bother with jump animations
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }


}