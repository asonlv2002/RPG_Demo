
using UnityEngine;

namespace StateContents
{
    using ColliderContents;
    internal class BodyAdapter : StateComponent, IBodyAdapter
    {
        ColliderCore _body;
        PlayerBody Body;
        public BodyAdapter(ColliderCore body)
        {
            _body = body;
            Body = _body as PlayerBody;
        }

        public bool IsTerrestrial => Body.FootTrack.IsTerrestrial;

        public bool IsOnGround => Body.FootTrack.IsOnGround;

        public float FLoatDirection => Body.FootTrack.FLoatDirection;

        public float AngleFeetGround => Body.FootTrack.AngleFeetGround;

        public Transform PlayerTransform => Body.PlayerTranform;
    }
}
