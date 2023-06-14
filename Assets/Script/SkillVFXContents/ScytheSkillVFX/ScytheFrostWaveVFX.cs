using UnityEngine;

namespace ScytheSkillVFX
{
    internal class ScytheFrostWaveVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem _frostWave;
        [SerializeField] Transform _characterSummon;
        [SerializeField] Vector3 _offsetPosition;
        [System.Obsolete]
        void SummonFrostWave()
        {
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
