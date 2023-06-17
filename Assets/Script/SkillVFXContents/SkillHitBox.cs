
namespace SkillVFXContents
{
    using UnityEngine;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DamgeContents;
    internal class SkillHitBox : MonoBehaviour
    {
        [SerializeField] ParticleSystem _particleSystem;
        List<GameObject> target;
        [SerializeField] float timeDelay = 1;
        [SerializeField] int Damge;

        private void Awake()
        {
            target= new List<GameObject>();
        }
        public void OnParticleCollision(GameObject other)
        {
            if(other.tag == "EnemyDamge")
            {
                if(target.IndexOf(other) == -1)
                {
                    target.Add(other);
                    ReadDamge(other);
                    var task = new Task(()=> RemoveTarget(other));
                    task.RunSynchronously();
                }
            }
        }

        async void RemoveTarget(GameObject gameObject)
        {
            int time = (int)(timeDelay * 1000);
            await Task.Delay(time);
            target.Remove(gameObject);

        }

        void ReadDamge(GameObject target)
        {
            var damageCore = target.GetComponent<DamgeCores>();
            if (!damageCore) return;
            var readDamge = damageCore.GetContentComponent<DamgeCaculator>();
            readDamge.TakenDamge(Damge);
            DamagePopupGenerator.Instance.Generator(target.transform.position, Damge.ToString(), Color.red);
        }
    }
}
