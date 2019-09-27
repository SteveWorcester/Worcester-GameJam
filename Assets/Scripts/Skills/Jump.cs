using Player;
using UnityEngine;

public class Jump : DirectionalCharge
{
    public KeyCode JumpButton = KeyCode.Space;
    [HideInInspector] public int JumpsLeft { get; set; }

    public PlayerPlatformerController player;

    private float m_jumpForce = 400f;
    private const int _amountOfJumps = 2;
    private bool jumpRequiresCharge = false;

    public void Update()
    {
        PlayerJump();
    }

    public void PlayerJump()
    {
        if (Input.GetKey(JumpButton))
        {
            if (jumpRequiresCharge)
            {
                StartCharge();
            }
        }

        else if (!jumpRequiresCharge)
        {
            JumpAction();
        }

        if (Input.GetKeyUp(JumpButton))
        {
            if (jumpRequiresCharge)
            {
                JumpAction();
            }
        }

        if (JumpsLeft > 0)
        {

        }
    }

    public void ResetJumps()
    {
        JumpsLeft = _amountOfJumps;
    }

    private void JumpAction()
    {
        player.m_rigidbody2D.AddForce(new Vector2(0f, m_jumpForce));
        JumpsLeft--;
    }
}
