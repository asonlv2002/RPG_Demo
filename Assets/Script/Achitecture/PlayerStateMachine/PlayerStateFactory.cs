using System.Collections;
using System.Collections.Generic;
namespace Achitecture
{
    internal class PlayerStateFactory
    {
        private Dictionary<string, PlayerBaseState> _states;
        public PlayerStateFactory(PlayerStateMachine context)
        {
            this.InitializationDictionaryStates();
        }

        private void InitializationDictionaryStates()
        {
            _states = new Dictionary<string, PlayerBaseState>();
        }
    }
}
