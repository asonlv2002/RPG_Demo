
using UnityEngine;

namespace StateContent
{
    using BodyCollider;
    internal class BodyAdapter : StateComponent, IBodyAdapter
    {
        PlayerBody Body;
        public BodyAdapter(PlayerBody body)
        {
            Body = body;
        }

        public bool IsTerrestrial => Body.FootTrack.IsTerrestrial;

        public bool IsOnGround => Body.FootTrack.IsOnGround;

        public float FLoatDirection => Body.FootTrack.FLoatDirection;

        public float AngleFeetGround => Body.FootTrack.AngleFeetGround;

        public Transform PlayerTransform => Body.PlayerTranform;
    }
}
