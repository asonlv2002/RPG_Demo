using UnityEngine;

namespace SkillVFXContents
{
    internal class ScytheFrostWaveVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem _frostWave;
        [SerializeField] Transform _characterSummon;
        [SerializeField] Vector3 _offsetPosition;
        RotateToTarget _rotateToTarget;
        private void Awake()
        {
            _rotateToTarget = GetComponent<RotateToTarget>();
        }
        [System.Obsolete]
        void SummonFrostWave()
        {
            StartCoroutine(_rotateToTarget.Rotate());
            _frostWave.transform.localPosition = _offsetPosition;
            _frostWave.transform.parent = null;
            _frostWave.gameObject.SetActive(true);
            _frostWave.Play();
            Invoke(nameof(EndFrostWave), 1f);
        }

        void EndFrostWave()
        {
            _frostWave.gameObject.SetActive(false);
            _frostWave.transform.parent = _characterSummon;
        }
    }
}
