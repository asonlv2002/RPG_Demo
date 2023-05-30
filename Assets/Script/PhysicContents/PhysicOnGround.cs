namespace PhysicContents
{
    using UnityEngine;
    [System.Serializable]
    internal class PhysicOnGround : PhysicComponent
    {
        const float CONST_FLOAT = 10f;
        [SerializeField] PhysicCore PhysicCore;

        public void FoatOnGround(float forceFloat)
        {
            PhysicCore.Y_VelocityApplie = forceFloat*CONST_FLOAT;
        }

        public void OnMoving(float Xspeed,float Zspeed)
        {
            PhysicCore.X_VelocityApplie = Xspeed;
            PhysicCore.Z_VelocityApplie = Zspeed;
        }
    }
}
