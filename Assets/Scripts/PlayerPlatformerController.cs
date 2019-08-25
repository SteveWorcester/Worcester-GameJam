using UnityEngine;
using UnityEngine.UI;

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
    TimeDilation td;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Used to limit player speed and allows player to jump
    /// </summary>
    public override void ComputeVelocity()
    {
        float jumpMultiplier = 5f;
        float knockbackMultiplier = -5f;

        Vector2 move = new Vector2(0, 0);
        move.x = Input.GetAxis("Horizontal");

        var mouseCoordinates = skillDirection.mouseCoordinates;
        float directionX = ((skillDirection.mouseCoordinates.x) - transform.position.x);
        float directionY = ((skillDirection.mouseCoordinates.y) - transform.position.y);

        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)  // Jump
        {
            velocity = new Vector2(directionX, directionY);
            velocity.Normalize();
            velocity = velocity * jumpMultiplier * slider.value;
            rb2d.AddForce(velocity, ForceMode2D.Impulse);
            print($"jump velocity: x:{velocity.x}, y:{velocity.y}");
        }

        if (Input.GetMouseButtonUp(0)) // "Shoot"
        {
            velocity = new Vector2(directionX, directionY);
            velocity.Normalize();
            velocity = velocity * knockbackMultiplier * slider.value;
            rb2d.AddForce(velocity, ForceMode2D.Impulse);
            print($"knockback velocity: x:{velocity.x}, y:{velocity.y}");
        }

        // THE ANIMATION ZONE!!!!!
        if (Input.GetKeyDown(KeyCode.D))
        {spriteRenderer.flipX = false;}
        else if (Input.GetKeyDown(KeyCode.A))
        {spriteRenderer.flipX = true;}

        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(velocity.x) / maxSpeed);   
        targetVelocity = move * maxSpeed;
    }
}