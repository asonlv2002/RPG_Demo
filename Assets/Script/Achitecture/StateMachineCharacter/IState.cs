using UnityEngine;

namespace Achitecture.StateMachineCharacter
{
    internal interface IState
    {
        public void EnterState();
        public void ExitState();

        public void HanldeInput();

        public void Update();

        public void PhysicsUpdate();

    }
}
