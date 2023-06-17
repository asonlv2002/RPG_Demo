using AnimatorContent;
using StatContents;
using UnityEngine;

namespace SkillVFXContents
{
    internal class ScytheFrostWaveVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem _frostWave;
        [SerializeField] Transform _characterSummon;
        [SerializeField] Vector3 _offsetPosition;
        RotateToTarget _rotateToTarget;
        private MPStat _mpStat;

        private void Start()
        {
            _rotateToTarget = GetComponent<RotateToTarget>();
        }
        [System.Obsolete]
        void SummonFrostWave()
        {
            InitLate();
            if (_mpStat.GetCurrentStatValue() < 20) return;
            _mpStat.SubCurrentStateValue(20);
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

        void InitLate()
        {
            if (_mpStat == null)
            {
                _mpStat = GetComponent<AnimatorCore>().MainCores.GetCore<StatCore>().GetContentComponent<MPStat>();
            }
        }
    }
}
