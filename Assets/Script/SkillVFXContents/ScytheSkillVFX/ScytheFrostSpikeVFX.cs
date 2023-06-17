using AnimatorContent;
using StatContents;
using UnityEngine;

namespace SkillVFXContents
{
    internal class ScytheFrostSpikeVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem _frostSpike;
        [SerializeField] RotateToTarget _rotate;
        private MPStat _mpStat;

        private void Start()
        {

        }
        void SummonFrostSpike()
        {
            InitLate();
            if (!_rotate.CheckDistacneToTarget(15f)) return;
            if (_mpStat.GetCurrentStatValue() < 20) return;
            _mpStat.SubCurrentStateValue(20);
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

        void InitLate()
        {
            if (_mpStat == null)
            {
                _mpStat = GetComponent<AnimatorCore>().MainCores.GetCore<StatCore>().GetContentComponent<MPStat>();
            }
        }
    }
}
