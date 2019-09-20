using Player;
using UnityEngine;
using UnityEngine.UI;


namespace Skills
{
    public class Skills : MonoBehaviour
    {
        public PlayerPlatformerController player;

        #region Fields
        // Modifiable Fields: 
        private float m_jumpForce = 400f;
        public const int _amountOfJumps = 2;

        // Unmodifiable Fields: 

        [HideInInspector] public int jumpsLeft { get; set; }

        #endregion
        public void FixedUpdate()
        {
            
        }

        public int Jump()
        {
            if (jumpsLeft > 0)
            {
                player.m_rigidbody2D.AddForce(new Vector2(0f, m_jumpForce));
                jumpsLeft--;
            }
            return jumpsLeft;
        }

        public void ResetJumps()
        {
            jumpsLeft = _amountOfJumps;
        }


        //jump?
        /*
            animator.SetBool("isGrounded", isGrounded);
            animator.SetFloat("Speed", Mathf.Abs(velocity.x) / maxSpeed);
            targetVelocity = move * maxSpeed;
        */



        //------THE OLD CODE STARTS HERE---------
        /*
        public Slider slider;
        public PlayerPlatformerController player;
        private float turnSpeed = 1;
        public float sliderFloat;
        public float chargeSpeed = 1.75f;
        public Text text;
        public (float x, float y) mouseCoordinates;

        void Start()
        {
            slider = GetComponent<Slider>();
        }

        void Update()
        {
            faceMouse();
            MoveToCharacter();
            GetChargeLevel();
            slider.value = sliderFloat;
            text.text = ("slider value = " + slider.value.ToString() + "\n " + "Mouse Position = " + Camera.main.ScreenToViewportPoint(Input.mousePosition) + "\n" + "Player position = " + player.transform.position + "\n");
        }

        public void faceMouse()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = new Vector2(
                mousePosition.x - transform.position.x,
                mousePosition.y - transform.position.y);

            transform.up = direction;
            transform.Rotate(Vector2.up, -turnSpeed * Time.deltaTime);

            mouseCoordinates = (mousePosition.x, mousePosition.y);
        }

        public void MoveToCharacter()
        {
            transform.position = player.transform.position;
        }

        /// <summary>
        /// Builds and releases charge value.
        /// </summary>
        /// <returns>sliderFloat Charge Level</returns>
        public float GetChargeLevel()
        {
            // TODO: cooldown timer/min charge?
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))  
            {
                sliderFloat += Time.unscaledDeltaTime * chargeSpeed;
            }

            if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
            {
                sliderFloat = 0;
            }

            return sliderFloat;
        }
        */
    }

}

