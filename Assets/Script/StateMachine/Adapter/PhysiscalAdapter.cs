
using UnityEngine;

namespace StateContent
{
    using Physical;
    internal class PhysiscalAdapter : StateComponent, IPhysicAdapter
    {
        PlayerPhysics _playerPhysics;
        public PhysiscalAdapter(PlayerPhysics playerPhysics)
        {
            _playerPhysics = playerPhysics;
        }
        public float Gravity => _playerPhysics.PhysiscVariable.Gravity;
        public float ConstFeet => 10f;
        public float Y_VelocityApplie { get =>  _playerPhysics.Y_VelocityApplie; set => _playerPhysics.Y_VelocityApplie = value; }
        public float X_VelocityApplie { get => _playerPhysics.X_VelocityApplie; set => _playerPhysics.X_VelocityApplie = value; }
        public float Z_VelocityApplie { get => _playerPhysics.Z_VelocityApplie; set => _playerPhysics.Z_VelocityApplie = value; }
        public Vector3 VelocityApplie { get => _playerPhysics.VelocityApplie; set => _playerPhysics.VelocityApplie = value; }
        public float JumpHeight => _playerPhysics.PhysiscVariable.JumpHeight;

        public Vector3 CurrenRigibodyVelocity =>  _playerPhysics.CurrentRiribodyVelocity;

        public float GetSpeedOnGroundDenpeden(float angleFeetGround)
        {
            return _playerPhysics.GetSpeedOnGroundDenpeden(angleFeetGround);
        }

        public void MovementForceApplie()
        {
            _playerPhysics.MovementForceApplie();
        }
    }
}
