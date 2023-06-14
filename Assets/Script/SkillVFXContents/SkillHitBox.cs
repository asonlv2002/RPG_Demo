
namespace SkillVFXContents
{
    using UnityEngine;
    internal class SkillHitBox : MonoBehaviour
    {
        [SerializeField] ParticleSystem _particleSystem;

        private void Awake()
        {
            Debug.Log(_particleSystem);
        }
        public void OnParticleCollision(GameObject other)
        {
            if(other.tag == "EnemyDamge")
            {
                Debug.Log(other.tag);
                DamagePopupGenerator.Instance.Generator(other.transform.position, "1000", Color.red);
            }

            
            
        }
    }
}
