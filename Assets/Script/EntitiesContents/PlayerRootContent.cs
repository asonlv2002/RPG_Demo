using UnityEngine;
namespace Entities
{
    internal class PlayerRootContent : MonoBehaviour
    {
        [field : SerializeField] public StateMachine.PlayerStateMachine StateMachine { get; private set; }
        [field : SerializeField] public Physical.PlayerPhysics Physiscal { get; private set; }
        [field: SerializeField] public BodyCollider.PlayerBody Body { get; private set; }
        [field: SerializeField] public AnimationAction.PlayerAnimator Animator { get; private set; }
        [field: SerializeField] public Input.PlayerInputAction InputAction { get; private set; }

        private void Start()
        {
            StateMachine.InitMainContent(this);
            Physiscal.InitMainContent(this);
            Body.InitMainContent(this);
        }
    }
}
