
using UnityEngine;

namespace StateContents
{
    using PhysicContents;
    internal class PhysiscalAdapter : StateComponent
    {
        PhysicCore _playerPhysics;
        PhysicInAir inAir;
        PhysicOnGround onGround;
        public PhysiscalAdapter(PhysicCore playerPhysics)
        {
            _playerPhysics = playerPhysics;
            inAir = _playerPhysics.GetContentComponent<PhysicInAir>();
            onGround = _playerPhysics.GetContentComponent<PhysicOnGround>();
        }
        public float Y_VelocityApplie { get =>  _playerPhysics.Y_VelocityApplie; set => _playerPhysics.Y_VelocityApplie = value; }
        public void MovementForceApplie()
        {
            _playerPhysics.ApplyVelocity();
        }

        public void GravityEffect(float present = 100f)
        {
            inAir.GravityEffect(present);
        }

        public void Jump(float jumpheight)
        {
            inAir.StartJump(jumpheight);
        }

        public void FloatOnGround(float f)
        {
            onGround.FoatOnGround(f);
        }

        public void Movement(float XSpeed,float Zspeed)
        {
            onGround.OnMoving(XSpeed, Zspeed);
        }

        public void StopOnAir(bool value)
        {
            inAir.StopOnAir(value);
        }

    }
}
