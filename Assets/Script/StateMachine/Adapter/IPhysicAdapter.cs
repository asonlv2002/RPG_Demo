namespace StateContent
{
    using UnityEngine;
    internal interface IPhysicAdapter
    {
        void MovementForceApplie();

        float Gravity { get; }
        float ConstFeet { get; }
        float JumpHeight { get; }
        float Y_VelocityApplie { get; set; }
        float X_VelocityApplie { get; set; }
        Vector3 CurrenRigibodyVelocity { get; }
        float Z_VelocityApplie { get; set; }
        Vector3 VelocityApplie { get; set; }


        float GetSpeedOnGroundDenpeden(float angleFeetGround);
    }
}
