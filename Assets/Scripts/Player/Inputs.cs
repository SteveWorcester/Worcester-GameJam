using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skills;

namespace Player
{
    public class Inputs : MonoBehaviour
    {
        public PlayerPlatformerController _player;

        KeyCode moveLeft = KeyCode.A;
        KeyCode moveRight = KeyCode.D;
        KeyCode grapplingHook = KeyCode.Mouse1;
        KeyCode jump = KeyCode.Space;
        KeyCode shoot = KeyCode.Mouse0;

        void FixedUpdate()
        {
            HandleMovementInput();
            HandleSkillsInput();
        }

        public void HandleMovementInput()
        {
            // Edit PlayerPlatformerController.Move() instead of these values!
            if (Input.GetKey(moveLeft))
            {
                _player.Move(-1f, false); 
            }
            else if (Input.GetKey(moveRight))
            {
                _player.Move(1f, false);
            }
        }

        public void HandleSkillsInput()
        {
            if (Input.GetKey(jump))
            {
                _player.Move(0, true);
            }
            if (Input.GetKey(shoot))
            {
                
            }
            if (Input.GetKey(grapplingHook))
            {
                
            }
        }
    }
}


