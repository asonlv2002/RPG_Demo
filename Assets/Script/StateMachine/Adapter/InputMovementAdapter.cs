﻿
using UnityEngine;

namespace StateContents
{
    using InputContents;
    internal class InputMovementAdapter: StateComponent
    {
        InputMovement InputMovement;
        public InputMovementAdapter(InputCore inputContent)
        {
            InputMovement = inputContent.GetContentComponent<InputMovement>();
        }

        public bool IsRunPressed => InputMovement.DirectionMovement !=0;

        public bool IsJumpPressed => InputMovement.IsJumpPressed;

        public bool IsSpintPressed => InputMovement.IsSpintPressed;

        public Vector3 CurrentInputMovement => InputMovement.CurrentInputMovement;

        public bool IsEquipPressed => InputMovement.IsEquipPressed;


        public float DirectionMove => InputMovement.DirectionMovement;

        public float DirectionRotate => InputMovement.DirectionRotation;
    }
}
