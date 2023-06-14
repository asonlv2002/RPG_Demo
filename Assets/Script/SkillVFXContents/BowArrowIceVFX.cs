using UnityEngine;

namespace SkillVFXContents
{
    internal class BowArrowIceVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem ArrowSplash;
        [SerializeField] ParticleSystem ArrowIceAttack;
        [SerializeField] ParticleSystem Enegy;
        [SerializeField] Transform _target;
        private void Awake()
        {
            ArrowSplash.gameObject.SetActive(false);
            ArrowIceAttack.gameObject.SetActive(false);
            Enegy.gameObject.SetActive(false);
        }

        [System.Obsolete]
        void ArrowIceShoot()
        {
            ArrowSplash.gameObject.SetActive(true);
            Enegy.gameObject.SetActive(true);
            ArrowSplash.Play();
            Enegy.Play();
            Invoke(nameof(IceShootTarget), Enegy.duration);
        }

        void IceShootTarget()
        {

            ArrowIceAttack.transform.parent = null;
            ArrowIceAttack.transform.position = new Vector3(_target.position.x,1,_target.position.z);
            ArrowIceAttack.gameObject.SetActive(true);
            ArrowIceAttack.Play();
        }
    }
}
