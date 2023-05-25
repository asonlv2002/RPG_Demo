
using UnityEngine;

namespace StateMachine
{
    using BodyCollider;
    internal class StateBodyAdapter : IStateBodyAdapter
    {
        PlayerBody Body;
        public StateBodyAdapter(PlayerBody body)
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
