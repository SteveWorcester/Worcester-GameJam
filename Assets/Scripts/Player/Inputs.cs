using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skills;

namespace Player
{
    public class Inputs : MonoBehaviour
    {
        PlayerPlatformerController player;
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
            if (Input.GetKeyDown(moveLeft))
            {
                player.Move(-1f, false); 
            }
            else if (Input.GetKeyDown(moveRight))
            {
                player.Move(1f, false);
            }
        }

        public void HandleSkillsInput()
        {
            if (Input.GetKeyDown(jump))
            {
                player.Move(0, true);
            }
            else if (Input.GetKeyDown(shoot))
            {
                
            }
            else if (Input.GetKeyDown(grapplingHook))
            {
                
            }
        }
    }
}


