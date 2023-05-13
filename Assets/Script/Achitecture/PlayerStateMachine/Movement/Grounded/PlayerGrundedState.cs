using UnityEngine;

namespace Achitecture
{
    internal class PlayerGrundedState : PlayerBaseState,IRootState
    {
        public PlayerGrundedState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) 
            : base(playerStateMachine, playerStateFactory)
        {
            _animtionHash = _context.AnimationHashs.IsGroundHash;
        }

        public override void CheckUpdateState()
        {
            if (_context.InputPress.IsJumpPressed || _context.Body.TrackingBodyOnGround.IsExitGrounded)
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
            if(_context.InputPress.IsRunPressed)
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
            //Float();
            //FloatBodyOnGround();
        }

        //private void FloatBodyOnGround()
        //{
        //    _context.PlayerPhysic.VelocityY = _context.Body.TrackingBodyOnGround.FLoatDirection * 10f - _context.PlayerPhysic.Physics.velocity.y ;
        //    _context.PlayerPhysic.VelocityX *= _context.PlayerPhysic.GetSpeedOnGroundDenpeden(_context.Body.TrackingBodyOnGround.AngleBodyWitHitGround);
        //    _context.PlayerPhysic.VelocityZ *= _context.PlayerPhysic.GetSpeedOnGroundDenpeden(_context.Body.TrackingBodyOnGround.AngleBodyWitHitGround);
        //}

        private void Float()
        {
            Vector3 capsuleColliderCenterInWorldSpace = _context.Body.CapsuleCollider.bounds.center;// stateMachine.Player.ResizableCapsuleCollider.CapsuleColliderData.Collider.bounds.center;

            Ray downwardsRayFromCapsuleCenter = new Ray(capsuleColliderCenterInWorldSpace, Vector3.down);

            if (Physics.Raycast(downwardsRayFromCapsuleCenter, out RaycastHit hit, _context.Body.SlopeData.RayDistance, LayerMask.GetMask(LayerMask.LayerToName(6)), QueryTriggerInteraction.Ignore))
            {
                float groundAngle = Vector3.Angle(hit.normal, -downwardsRayFromCapsuleCenter.direction);

                float slopeSpeedModifier = _context.PlayerPhysic.GetSpeedOnGroundDenpeden(groundAngle);

                if (slopeSpeedModifier == 0f)
                {
                    return;
                }

                float distanceToFloatingPoint = _context.Body.CenterCapsuleInLocalSpace.y - hit.distance;

                if (distanceToFloatingPoint == 0f)
                {
                    return;
                }

                float amountToLift = distanceToFloatingPoint * 10f - _context.PlayerPhysic.Physics.velocity.y;
                _context.PlayerPhysic.VelocityY = amountToLift;
                //Vector3 liftForce = new Vector3(0f, amountToLift, 0f);
            }
        }

    }
}
