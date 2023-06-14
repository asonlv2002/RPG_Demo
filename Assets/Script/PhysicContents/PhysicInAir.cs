
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
            //if (jumpHeiht == 0)
            //{
            //    var rb = PhysicCore.PhysiscHandler;
            //    rb.velocity = UnityEngine.Vector3.zero;
            //    return;
            //}
            PhysicCore.Y_VelocityApplie = JUMPHEIGHT;
        }
        public void StopOnAir(bool value)
        {
            PhysicCore.PhysiscHandler.isKinematic = value;
        }

        public void Fly(float vector)
        {
            PhysicCore.Y_VelocityApplie = vector;
        }
    }
}
