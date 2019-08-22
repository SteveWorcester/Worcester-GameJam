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
    private float sliderFloat;
    public float chargeSpeed;
    protected Slider slider;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    void Awake()
    {
        //grab the spriterenderer, and apply the animator, even if they won't do shit for a bit.
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        slider = GetComponent<Slider>();
    }

    //a velocity grabber of some sort - lets us calculate if player is going too fast, and stop it.
    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");

        // ChargeAim()  //REAL JUMP

        if (Input.GetButtonDown("Jump") && isGrounded)  //TEMP JUMP, this is just to make me happy for a short period of time.
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
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

    public float ChargeAim()
    {
        //let it charge up when jump is pressed
        while (Input.GetButtonDown("Jump"))
        {
            sliderFloat = sliderFloat + chargeSpeed;
        }

        //make something happen when jump is released, based on the charge value

        return sliderFloat;
    }
}