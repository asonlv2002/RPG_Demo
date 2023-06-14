﻿using UnityEngine;

namespace SkillVFXContents
{
    internal class BowArrowFireVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem _fireArrow;
        [SerializeField] ParticleSystem _enery;
        [SerializeField] Transform _firePoint;
        [SerializeField] RotateToTarget _rotate;


        private void Start()
        {
            _fireArrow.gameObject.SetActive(false);
            _enery.gameObject.SetActive(false);
        }
        [System.Obsolete]
        void ArrowFire()
        {
            StartCoroutine(_rotate.Rotate());
            _enery.gameObject.SetActive(true);
            _enery.Play();
            Shoot();
        }

        [System.Obsolete]
        void Shoot()
        {
            _fireArrow.Play();
            var forward = _rotate.Target.position - _firePoint.position;
            _fireArrow.transform.forward = forward.normalized;
            var offset = Vector3.one * -0.25f;
            _fireArrow.transform.position = _firePoint.position+ offset;
            _fireArrow.transform.localEulerAngles = Vector3.zero;
            _fireArrow.gameObject.SetActive(true);
        }
    }

}
