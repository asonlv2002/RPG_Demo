using AnimatorContent;
using StatContents;
using UnityEngine;

namespace SkillVFXContents
{
    internal class ScytheDarkBombVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem DarkBomb;
        [SerializeField] RotateToTarget _rotate;
        [SerializeField] Transform FirePoint;
        [SerializeField] Vector3 offSet;
        private MPStat _mpStat;

        void SummonDarkBoom()
        {
            InitLate();
            if (!_rotate.CheckDistacneToTarget(10f)) return;
            if (_mpStat.GetCurrentStatValue() < 20) return;
            _mpStat.SubCurrentStateValue(20);
            StartCoroutine(_rotate.Rotate());
            var projectile = MonoBehaviour.Instantiate(DarkBomb.gameObject, FirePoint.position+ offSet, FirePoint.rotation);
            projectile.SetActive(true);
            projectile.GetComponent<TargetProjectile>().UpdateTarget(_rotate.Target, Vector3.zero);
        }

        void InitLate()
        {
            if (_mpStat == null)
            {
                _mpStat = GetComponent<AnimatorCore>().MainCores.GetCore<StatCore>().GetContentComponent<MPStat>();
            }
        }
    }


}
