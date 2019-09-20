using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skills;

namespace Player
{
    public class Inputs : MonoBehaviour
    {
        public PlayerPlatformerController _player;

        #region Private Fields

        KeyCode _moveLeft = KeyCode.A;
        KeyCode _moveRight = KeyCode.D;
        KeyCode _grapplingHook = KeyCode.Mouse1;
        KeyCode _jump = KeyCode.Space;
        KeyCode _shoot = KeyCode.Mouse0;

        #endregion



        void FixedUpdate()
        {
            HandleMovementInput();
            HandleSkillsInput();
        }

        public void HandleMovementInput()
        {
            // Edit PlayerPlatformerController.Move() instead of these values!
            if (Input.GetKey(_moveLeft))
            {
                _player.Move(-1f, false); 
            }
            if (Input.GetKey(_moveRight))
            {
                _player.Move(1f, false);
            }
            if (Input.GetKeyDown(_jump))
            {
                _player.Move(0, true);
            }
        }

        public void HandleSkillsInput()
        {

            if (Input.GetKey(_shoot))
            {
                
            }
            if (Input.GetKey(_grapplingHook))
            {
                
            }
        }
    }
}


