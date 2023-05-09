using UnityEngine;
namespace Achitecture
{
    internal class PlayerMovementState : PlayerBaseState, IRootState
    {
        public PlayerMovementState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) :
            base(playerStateMachine, playerStateFactory)
        {
        }

        public override void CheckUpdateState()
        {

        }

        public override void EnterState()
        {
            SetJumpVariabes();
            UnityEngine.Debug.Log("Movement");
            InitializationSubState();
        }

        public override void UpdateState()
        {

            base.UpdateState();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            _context.PlayerPhysic.Physics.velocity =_context._applyMovement;
            Rotation();
        }

        public void InitializationSubState()
        {
            if(_context.IsGrounded)
            {
                SetChildState(_factory.Grounded());
            }else
            {
                SetChildState(_factory.Airborne());
            }
            _childState.EnterState();
        }

        private void SetJumpVariabes()
        {
            float timeToApex = _context.MaxTimeJump / 2;

            _context.Gravity = (-2 * _context.MaxJumpHeight) / Mathf.Pow(timeToApex, 2);

            _context.InitialJumpVelocity = (2 * _context.MaxJumpHeight) / timeToApex;
        }

        private void Rotation()
        {
            Vector3 postionToLookAt;

            postionToLookAt.x = _context._currentMovement.x;
            postionToLookAt.y = 0f;
            postionToLookAt.z = _context._currentMovement.z;

            Quaternion currentRotation = _context.transform.rotation;

            if (_context.IsRunPressed)
            {
                Quaternion targetRoation = Quaternion.LookRotation(postionToLookAt);
                _context.transform.rotation = Quaternion.Slerp(currentRotation, targetRoation, 20f * Time.deltaTime);
            }
        }
    }
}
