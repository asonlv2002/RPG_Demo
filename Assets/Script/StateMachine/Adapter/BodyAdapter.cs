
using UnityEngine;

namespace StateContents
{
    using ColliderContents;
    internal class BodyAdapter : StateComponent
    {
        ColliderCore _body;
        PlayerBody Body;
        TransFormContent transFormContent;
        public BodyAdapter(ColliderCore body)
        {
            _body = body;
            Body = _body as PlayerBody;
            transFormContent = _body.GetContentComponent<TransFormContent>();

        }

        public bool IsTerrestrial => Body.FootTrack.IsTerrestrial;

        public bool IsOnGround => Body.FootTrack.IsOnGround;

        public float FLoatDirection => Body.FootTrack.FLoatDirection;

        public float AngleFeetGround => Body.FootTrack.AngleFeetGround;

        public void Rotation(float direction)
        {
            transFormContent.Rotation(direction);
        }

    }
}
