using UnityEngine;

namespace SkillVFXContents
{
    internal class BowArrowFireVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem _fireArrow;
        [SerializeField] ParticleSystem _enery;
        [SerializeField] Transform _firePoint;

        [System.Obsolete]
        void ArrowFire()
        {
            _enery.Play();
            Shoot();
        }

        void Shoot()
        {
            _fireArrow.Play();
            _fireArrow.transform.forward = _firePoint.forward;
            var offset = Vector3.one * -0.25f;
            _fireArrow.transform.position = _firePoint.position+ offset;
            _fireArrow.transform.localEulerAngles = Vector3.zero;
        }

    }

}
