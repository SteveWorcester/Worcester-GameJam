using Player;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public KeyCode JumpButton = KeyCode.Space;
    [HideInInspector] public int jumpsLeft { get; set; }

    public PlayerPlatformerController player;
    public DirectionalCharge charger;

    private float m_jumpForce = 400f;
    [HideInInspector] public const int _amountOfJumps = 2;
    private bool jumpRequiresCharge = false;

    public void Update()
    {
        PlayerJump();
    }

    public int PlayerJump()
    {
        if (jumpRequiresCharge)
        {
            charger.StartCharge();
        }

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
}
