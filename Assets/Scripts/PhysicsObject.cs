using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//generic physics object - everything that can fall or be colided with belongs in this class, or in a child of this class.  This may, or may not include things like projectiles, monsters, etc.

public class PhysicsObject : MonoBehaviour
{
    //speeds and gravity mods.  should be public facing
    public float minGroundNormalY = .65f;
    public float gravityModifier = 1f;

    //variables influenced by the previous two through gameplay.  These shouldn't be changed manually.
    protected Vector2 targetVelocity;
    protected bool isGrounded;
    protected Vector2 groundNormal;
    protected Rigidbody2D rb2d;
    protected Vector2 velocity;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);
    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    // we want the rigidbody to turn on immediately when a physics object is enabled - this should stop pass-through
    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    void Update()  //The ONLY thing that should be in here is velocity calculations
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity();
        //make the slider on child PlayerPlatformerController roatate based on current direction pressed?
    }

    public virtual void ComputeVelocity() {}

    void FixedUpdate()  //The ONLY thing allowed in here is physics stuff - collisions, checks, etc.
    {
        //gravity calculations come first.
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = targetVelocity.x;

        //then check if the object is touching something along the gravity axis.
        isGrounded = false;

        //time.deltatime calculation for expected position counting for velocity - and keep on the ground if it's already touching.
        Vector2 deltaPosition = velocity * Time.deltaTime;
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x;

        //calling movement while on the ground
        Movement(move, false);

        //This is waht we will need to change if we want to alter gravity.  later, much later.
        move = Vector2.up * deltaPosition.y;

        //calling movement while in the air
        Movement(move, true);
    }

    void Movement(Vector2 move, bool yMovement)  //fuck my rewrites, just sticking this into a function
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance)  //don't let the player move if they're trying to move less than a pixel... because fuck pixel perfect jumps.
        {
            //count how many things the object is colliding with, so we can have multiple collisions based on inputs.
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear();
            for (int i = 0; i < count; i++) {hitBufferList.Add(hitBuffer[i]);}

            //use the buffer to kick back movement vectors.
            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;
                if (currentNormal.y > minGroundNormalY) //fuck pixel perfect jumps
                {
                    isGrounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0)
                {
                    velocity = velocity - projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }


        }

        //Finally, calculate distance between it's position and it's normalized move value.
        rb2d.position = rb2d.position + move.normalized * distance;
    }


}