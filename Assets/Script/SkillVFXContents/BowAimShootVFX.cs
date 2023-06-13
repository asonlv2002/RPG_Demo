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
        [SerializeField] Transform target;

        LoopParticaleSystem _loopTrails;
        LoopParticaleSystem _loopEnegy;

        private void Awake()
        {
            Debug.Log(Enegy.GetComponent<LoopParticaleSystem>());
            _loopEnegy = Enegy.transform.GetComponent<LoopParticaleSystem>();
            _loopTrails = Trails.transform.GetComponent<LoopParticaleSystem>();
        }
        void AbsorbEnergy()
        {
            _loopTrails.PlayInLoop();
            _loopEnegy.PlayInLoop();
            ShokcWave.Play();
        }

        void Shoot()
        {
            _loopTrails.SetEndLoop(true);
            _loopEnegy.SetEndLoop(true);
            GameObject projectile = Instantiate(ProjectTile, FirePoint.position, FirePoint.rotation);
            projectile.GetComponent<TargetProjectile>().UpdateTarget(target, Vector3.zero);
        }
    }
}
