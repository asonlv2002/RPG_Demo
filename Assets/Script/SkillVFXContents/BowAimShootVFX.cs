﻿using UnityEngine;

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

        private void Awake()
        {
            _loopEnegy = Enegy.transform.GetComponent<LoopParticaleSystem>();
            _loopTrails = Trails.transform.GetComponent<LoopParticaleSystem>();
        }
        void AbsorbEnergy()
        {
            StartCoroutine(_rotate.Rotate());
            _loopTrails.gameObject.SetActive(true);
            _loopEnegy.gameObject.SetActive(true);
            _loopTrails.PlayInLoop();
            _loopEnegy.PlayInLoop();
            ShokcWave.Play();
        }

        void StrongShoot()
        {
            _loopTrails.SetEndLoop(true);
            _loopEnegy.SetEndLoop(true);
            GameObject projectile = Instantiate(ProjectTile, FirePoint.position, FirePoint.rotation);
            projectile.GetComponent<TargetProjectile>().UpdateTarget(_rotate.Target, Vector3.zero);
        }
    }
}
