namespace StatContents
{
    using UnityEngine;
    using System.Threading.Tasks;
    using System.Collections;
    [System.Serializable]
    internal class HealHpPerSecond : StatBase
    {
        [SerializeField] StatCore _statCore;
        public override void OnAddComponent()
        {
            base.OnAddComponent();
            //HandleHeal();
            _statCore.StartCoroutine(Handle());
        }
        
        IEnumerator Handle()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                _statCore.GetContentComponent<HPStat>().AddCurrentStatValue(CurrentStatValue);
            }
        }
        public override void OnRemoveComponent()
        {
            _statCore.StopCoroutine(Handle());
        }
    }
}
