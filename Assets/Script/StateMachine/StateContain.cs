using System.Collections.Generic;

namespace StateMachine
{
    internal abstract class StateContain
    {
        protected IStateContext _stateContext;
        public StateContain(IStateContext stateContext)
        {
            _stateContext = stateContext;
            CreateStateContain();
        }
        protected abstract void CreateStateContain();
    }
}
