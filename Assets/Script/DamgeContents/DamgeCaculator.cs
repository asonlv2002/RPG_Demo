namespace DamgeContents
{
    using UnityEngine;
    using UnityEngine.Events;
    internal class DamgeCaculator : DamgeComponent
    {
        public UnityAction<int> OnDamageTaken;


        public void TakenDamge(int damge)
        {
            OnDamageTaken.Invoke(damge);
        }
    }
}
