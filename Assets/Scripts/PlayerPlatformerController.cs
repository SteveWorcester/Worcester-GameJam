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
    public float x, y, distance;
    public Vector2 direction;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Slider slider;
    public SkillDirection skillDirection;
    public Rigidbody2D rb2d;


    void Awake()
    {
        //grab the spriterenderer, and apply the animator, even if they won't do shit for a bit.
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    //a velocity grabber of some sort - lets us calculate if player is going too fast, and stop it.
    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");

        if (Input.GetMouseButtonUp(0) && isGrounded)  //TEMP JUMP, this is just to make me happy for a short period of time.
        {
            //set 2d velocity, targeting current mouse location.
            Vector2 mouse = new Vector2(
                Camera.main.ScreenToViewportPoint(Input.mousePosition).x - transform.position.x, 
                Camera.main.ScreenToViewportPoint(Input.mousePosition).y - transform.position.y);
            distance = slider.value;
            direction = mouse / distance; // This is now the normalized direction.
            velocity = new Vector2(Mathf.Clamp(slider.value * 10, 0,10), Mathf.Clamp(slider.value * 10, 0, 10));

            rb2d.AddForce(velocity, ForceMode2D.Impulse);
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