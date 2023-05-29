using System.Collections.Generic;

namespace StateContent
{
    internal abstract class StateStore : StateComponent
    {
        protected IStateContent _stateContent;
        public StateStore(IStateContent stateContent)
        {
            _stateContent = stateContent;
            CreateStateContain();
        }
        protected abstract void CreateStateContain();
    }
}
