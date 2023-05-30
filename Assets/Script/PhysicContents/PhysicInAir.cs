
namespace PhysicContents
{
    [System.Serializable]
    internal class PhysicInAir : PhysicComponent
    {
        const float GRAVITY = -32f;
        const float JUMPHEIGHT = 8f;
        [UnityEngine.SerializeField] PhysicCore PhysicCore;
        public void GravityEffect(float percentGravity = 100f)
        {
            var oldYVelocity = PhysicCore.Y_VelocityApplie;
            var newVelocityY = PhysicCore.Y_VelocityApplie + GRAVITY* (percentGravity/100f)* UnityEngine.Time.fixedDeltaTime;
            PhysicCore.Y_VelocityApplie = (oldYVelocity + newVelocityY) * .5f;
        }

        public void StartJump(float jumpHeiht = 8f)
        {
            PhysicCore.Y_VelocityApplie = JUMPHEIGHT;
        }
    }
}
