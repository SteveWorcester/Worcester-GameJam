using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerPlatformerController : MonoBehaviour
    {

        public Inputs InputHandler;

        #region Private Fields

        private float m_JumpForce = 400f;
        [Range(0, .3f)] private float m_movementSmoothingTime = .05f; // Time it takes to accelerate/decelerate.
        private float m_moveSpeedMultiplier = 10f;
        private bool m_AirControl = true;  // Can you steer left/right while jumping?
        private LayerMask m_WhatIsGround;
        private Transform m_GroundCheck;
        private Transform m_CeilingCheck;
        private bool m_Grounded;
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;
        private Vector2 m_Velocity = Vector2.zero;

        #endregion

        [Header("Events")]
        [Space]

        public UnityEvent OnLandEvent;

        public class BoolEvent : UnityEvent<bool> { }

        private void Awake()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();

            if (OnLandEvent == null)
                OnLandEvent = new UnityEvent();
        }

        private void FixedUpdate()
        {
            bool wasGrounded = m_Grounded;
            m_Grounded = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                    if (!wasGrounded)
                    {
                        OnLandEvent.Invoke();
                    }
                }
            }
        }

        /// <summary>
        /// Controls left, right, and jump movements.
        /// </summary>
        /// <param name="moveDirection">negative moves left; positive moves right</param>
        /// <param name="jump"></param>
        public void Move(float moveDirection, bool jump)
        {
            if (m_Grounded || m_AirControl)
            {
                Vector2 targetVelocity = new Vector2(moveDirection * m_moveSpeedMultiplier, m_Rigidbody2D.velocity.y);
                m_Rigidbody2D.velocity = Vector2.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_movementSmoothingTime);

                if (moveDirection > 0 && !m_FacingRight)
                {
                    ChangeSpriteFacing();
                }
                else if (moveDirection < 0 && m_FacingRight)
                {
                    ChangeSpriteFacing();
                }
            }

            if (m_Grounded && jump)
            {
                m_Grounded = false;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
        }

        private void ChangeSpriteFacing()
        {
            m_FacingRight = !m_FacingRight;

            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }





    //public Inputs _Input;
    //
    //
    //Animator _animator;
    //
    //private void Start()
    //{
    //    SpriteRenderer sprite = GetComponent<SpriteRenderer>();
    //    _animator = GetComponent<Animator>();
    //    rb2d = GetComponent<Rigidbody2D>();
    //}
    //
    //private void Update()
    //{
    //    _animator.
    //}





    //-----THE OLD CODE STARTS HERE--------
    /*
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
    public TimeDilation td;

    #region Controls

    private KeyCode jumpButton = KeyCode.Space;
    private KeyCode shootButton = KeyCode.Mouse0;

    #endregion

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckKeyDownForTimeDilation();
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

    private void CheckKeyDownForTimeDilation()
    {
        if (true)
        {

        }
    }
    */
}

