namespace DamgeContents
{
    using Achitecture;
    using UnityEngine;
    internal class PlayerDamgeTaken : DamgeCores
    {
        [SerializeField] TakeDamgeCalulator _takeDamgeCalulator;
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            AddContentComponent(_takeDamgeCalulator);

        }
        public void OnTriggerEnter(Collider other)
        {
            _takeDamgeCalulator.OnDamgeTrigger(other.gameObject);
        }
    }
}
