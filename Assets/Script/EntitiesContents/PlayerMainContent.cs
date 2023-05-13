using UnityEngine;
using Achitecture.StateMachine;
using Physical;
using BodyCollider;
namespace EntitiesContents
{
    internal class PlayerMainContent : MonoBehaviour
    {
        [field : SerializeField] public PlayerStateMachine StateMachine { get; private set; }
        [field : SerializeField] public PlayerPhysics Physiscal { get; private set; }

        [field: SerializeField] public PlayerBody Body { get; private set; }

        private void Awake()
        {
            StateMachine.InitMainContent(this);
            Physiscal.InitMainContent(this);
            Body.InitMainContent(this);
        }
    }
}
