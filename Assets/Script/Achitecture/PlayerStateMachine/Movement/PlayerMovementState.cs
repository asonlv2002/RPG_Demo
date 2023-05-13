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
            UnityEngine.Debug.Log("Movement");
            base.EnterState();
            InitializationSubState();
        }

        public override void UpdateState()
        {

            base.UpdateState();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Movement();
            Rotation();
        }

        public void InitializationSubState()
        {
            if(_context.Body.TrackingBodyOnGround.IsExitGrounded)
            {
                SetChildState(_factory.Grounded());
            }else
            {
                SetChildState(_factory.Airborne());
            }
            _childState.EnterState();
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
                _context.transform.rotation = Quaternion.Slerp(currentRotation, targetRoation, 20f * Time.deltaTime);
            }
        }

        private void Movement()
        {
            Float();
            _context._cameraRelativeMovement = _context.ConvertToCameraSpace(_context.PlayerPhysic.Velocity);
            _context.PlayerPhysic.Physics.velocity = _context._cameraRelativeMovement;
        }

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
