
namespace SkillVFXContents
{
    using UnityEngine;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    internal class SkillHitBox : MonoBehaviour
    {
        [SerializeField] ParticleSystem _particleSystem;
        List<GameObject> target;
        [SerializeField] float timeDelay = 1;

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
                    DamagePopupGenerator.Instance.Generator(other.transform.position, "1000", Color.red);
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
    }
}
