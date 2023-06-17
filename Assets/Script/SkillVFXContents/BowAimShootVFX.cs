using AnimatorContent;
using StatContents;
using UnityEngine;

namespace SkillVFXContents
{
    internal class BowAimShootVFX : MonoBehaviour
    {
        [SerializeField] Transform FirePoint;
        [SerializeField] ParticleSystem Enegy;
        [SerializeField] ParticleSystem Trails;
        [SerializeField] ParticleSystem ShokcWave;
        [SerializeField] GameObject ProjectTile;
        [SerializeField] RotateToTarget _rotate;


        LoopParticaleSystem _loopTrails;
        LoopParticaleSystem _loopEnegy;
        MPStat _mpStat;

        private void Start()
        {
            _loopEnegy = Enegy.transform.GetComponent<LoopParticaleSystem>();
            _loopTrails = Trails.transform.GetComponent<LoopParticaleSystem>();
        }
        void AbsorbEnergy()
        {
            InitLate();

            if (!_rotate.CheckDistacneToTarget(15f)) return;
            if (_mpStat.GetCurrentStatValue() <20) return;
            _mpStat.SubCurrentStateValue(20);
            StartCoroutine(_rotate.Rotate());
            _loopTrails.gameObject.SetActive(true);
            _loopEnegy.gameObject.SetActive(true);
            _loopTrails.PlayInLoop();
            _loopEnegy.PlayInLoop();
            ShokcWave.Play();
        }

        void StrongShoot()
        {
            if (!_rotate.CheckDistacneToTarget(15f)) return;
            _loopTrails.SetEndLoop(true);
            _loopEnegy.SetEndLoop(true);
            GameObject projectile = Instantiate(ProjectTile, FirePoint.position, FirePoint.rotation);
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
