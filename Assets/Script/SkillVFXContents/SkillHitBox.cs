
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
            Debug.Log(other.tag);
        }
    }
}
