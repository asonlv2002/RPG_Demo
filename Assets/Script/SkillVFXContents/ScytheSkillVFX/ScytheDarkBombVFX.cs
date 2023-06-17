using UnityEngine;

namespace SkillVFXContents
{
    internal class ScytheDarkBombVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem DarkBomb;
        [SerializeField] RotateToTarget _rotate;
        [SerializeField] Transform FirePoint;
        [SerializeField] Vector3 offSet;
        void SummonDarkBoom()
        {
            if (!_rotate.CheckDistacneToTarget(10f)) return;
            StartCoroutine(_rotate.Rotate());
            var projectile = MonoBehaviour.Instantiate(DarkBomb.gameObject, FirePoint.position+ offSet, FirePoint.rotation);
            projectile.SetActive(true);
            projectile.GetComponent<TargetProjectile>().UpdateTarget(_rotate.Target, Vector3.zero);
        }
    }


}
