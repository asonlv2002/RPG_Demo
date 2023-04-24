using UnityEngine;
using Achitecture.Entities;
namespace Player.InputComponent
{
    internal class Input : EntityComponent
    {
        public PlayerInput InputAction { get; private set; }
        public PlayerInput.PlayerActions PlayerActions { get; private set; }

        public override void InitializationComponent(EntityController entityController)
        {
            base.InitializationComponent(entityController);

            InputAction = new PlayerInput();

            PlayerActions = InputAction.Player;
        }
    }
}
