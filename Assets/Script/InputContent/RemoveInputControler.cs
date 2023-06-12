namespace InputContents
{
    using System.Threading.Tasks;
    using UnityEngine;

    internal class RemoveInputControler
    {
        private float runTime;
        bool isAttacking;
        private float deltaTimedDeleteInput = 0.1f;
        System.Action _deleteInput;
        public RemoveInputControler(System.Action action,float deltaTimedDeleteInput)
        {
            this.deltaTimedDeleteInput = deltaTimedDeleteInput;
            _deleteInput = action;
        }

        public async void RunTimeReduce()
        {
            runTime = deltaTimedDeleteInput;

            while (isAttacking == false)
            {
                await Task.Delay(10);
                runTime -= Time.deltaTime;
                if (runTime <= 0)
                {
                    _deleteInput.Invoke();
                    Debug.Log("Delete");
                    return;
                }

            }
        }

        public void EndTask(bool _isAttacking)
        {
            isAttacking = _isAttacking;
        }
    }


}
