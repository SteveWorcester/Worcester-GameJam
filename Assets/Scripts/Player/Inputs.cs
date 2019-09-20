using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Inputs : MonoBehaviour
    {
        public PlayerPlatformerController _player;
        public Skills.Skills _Skills;

        #region Fields

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

        }

        public void HandleSkillsInput()
        {
            if (Input.GetKeyDown(_jump))
            {
                _Skills.Jump();
            }
            if (Input.GetKey(_shoot))
            {
                
            }
            if (Input.GetKey(_grapplingHook))
            {
                
            }
        }
    }
}


