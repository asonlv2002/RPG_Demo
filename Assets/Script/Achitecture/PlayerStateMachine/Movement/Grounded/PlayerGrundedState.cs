using UnityEngine;

namespace Achitecture
{
    internal class PlayerGrundedState : PlayerBaseState,IRootState
    {
        float liftFloat;
        public PlayerGrundedState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) 
            : base(playerStateMachine, playerStateFactory)
        {
            _animtionHash = _context.AnimationHashs.IsGroundHash;
        }

        public override void CheckUpdateState()
        {
            if (_context.IsJumpPressed || !_context.IsGrounded)
            {
                SwitchState(_factory.Airborne());
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Grounded");
            InitializationSubState();
        }
        public override void UpdateState()
        {

            base.UpdateState();
            CheckUpdateState();
        }
        public void InitializationSubState()
        {
            if(_context.IsRunPressed)
            {
                SetChildState(_factory.Run());
            }else 
            {
                SetChildState(_factory.StopOnGround());
            }
            _childState.EnterState();
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            FloatCapsulaCollier();
            GravityEffect();
        }
        private void GravityEffect()
        {
            _context._currentMovement.y = liftFloat;
            _context._applyMovement.y = liftFloat;
        }

        private void FloatCapsulaCollier()
        {
            Vector3 capsuleCenterWorldSpace = _context.CalculateCapsuleUtility.CapsuleColliderData.CenterCapsuleInWorldSpace;
            Ray downwardRay = new Ray(capsuleCenterWorldSpace, Vector3.down);
            float rayDistance = _context.CalculateCapsuleUtility.SlopeData.RayDistance;
            float distaneToHitPoint;
            if (Physics.Raycast(downwardRay, out RaycastHit hit, rayDistance,LayerMask.GetMask("Default"),QueryTriggerInteraction.Ignore))
            {
                float hitDistance = hit.distance;
                distaneToHitPoint = _context.CalculateCapsuleUtility.CapsuleColliderData.CenterCapsuleInLocalSpace.y - hitDistance;
                liftFloat = distaneToHitPoint*10f;
            }
        }
    }
}
