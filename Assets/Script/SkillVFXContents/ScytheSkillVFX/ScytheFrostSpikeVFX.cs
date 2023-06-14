using UnityEngine;

namespace ScytheSkillVFX
{
    internal class ScytheFrostSpikeVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem _frostSpike;
        [SerializeField] Transform _target;

        void SummonFrostSpike()
        {
            var  positionTarget = _target.position;
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
