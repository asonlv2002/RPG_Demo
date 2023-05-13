using UnityEngine;

namespace Achitecture.StateMachine
{
    internal class PlayerMoveState : PlayerBaseState , IRootState
    {
        public PlayerMoveState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            _animtionHash = _context.AnimationHashs.IsMoveHash;
        }

        public override void CheckUpdateState()
        {
            if(!_context.InputPress.IsRunPressed)
            {
                SwitchState(_factory.StopOnGround());
            }
        }
        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Moving");
            InitializationSubState();
        }

        public override void UpdateState()
        {

            base.UpdateState();
            CheckUpdateState();
        }

        public void InitializationSubState()
        {
            if(_context.InputPress.IsRunPressed)
            {
                SetChildState(_factory.Run());
            }
            if(_context.InputPress.IsSpintPressed)
            {
                SetChildState(_factory.Sprint());
            }
            _childState.EnterState();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            ConvertDirection();
            Rotation();
            //Move();
        }

        private void Rotation()
        {
            Vector3 postionToLookAt;

            postionToLookAt.x = _context._cameraRelativeMovement.normalized.x;
            postionToLookAt.y = 0f;
            postionToLookAt.z = _context._cameraRelativeMovement.normalized.z;

            Quaternion currentRotation = _context.transform.rotation;

            if (_context.InputPress.IsRunPressed)
            {
                Quaternion targetRoation = Quaternion.LookRotation(postionToLookAt);
                _context.transform.rotation = Quaternion.Slerp(currentRotation, targetRoation, 20f * Time.fixedDeltaTime);
            }
        }

        private void ConvertDirection()
        {
            _context._cameraRelativeMovement = _context.ConvertToCameraSpace(_context.InputPress.CurrentInputMovement);
        }

        //void Move()
        //{
        //    _context.PlayerPhysic.VelocityX = _context._cameraRelativeMovement.normalized.x * 4;
        //    _context.PlayerPhysic.VelocityZ = _context._cameraRelativeMovement.normalized.z * 4;
        //}
    }
}
