using System.Collections.Generic;

namespace StateContents
{
    internal abstract class StateStore : StateComponent
    {
        protected StateCore _stateContent;
        public StateStore(StateCore stateContent)
        {
            _stateContent = stateContent;
            CreateStateContain();
        }
        protected abstract void CreateStateContain();


    }
}
