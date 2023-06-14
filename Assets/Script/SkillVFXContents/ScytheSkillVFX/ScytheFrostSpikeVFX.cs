using UnityEngine;

namespace SkillVFXContents
{
    internal class ScytheFrostSpikeVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem _frostSpike;
        [SerializeField] RotateToTarget _rotate;

        void SummonFrostSpike()
        {
            StartCoroutine(_rotate.Rotate());
            var  positionTarget = _rotate.Target.position;
            positionTarget.y = 1;
            _frostSpike.transform.position = positionTarget;
            _frostSpike.gameObject.SetActive(true);
            Invoke(nameof(End), 1f);
        }

        void End()
        {
            _frostSpike.Stop();
            _frostSpike.gameObject.SetActive(false);
        }
    }
}
