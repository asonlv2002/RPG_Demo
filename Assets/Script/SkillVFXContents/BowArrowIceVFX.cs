using AnimatorContent;
using StatContents;
using UnityEngine;

namespace SkillVFXContents
{
    internal class BowArrowIceVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem ArrowSplash;
        [SerializeField] ParticleSystem ArrowIceAttack;
        [SerializeField] ParticleSystem Enegy;
        [SerializeField] RotateToTarget Rotate;
        private MPStat _mpStat;

        private void Start()
        {
            ArrowSplash.gameObject.SetActive(false);
            ArrowIceAttack.gameObject.SetActive(false);
            Enegy.gameObject.SetActive(false);
        }

        [System.Obsolete]
        void ArrowIceShoot()
        {
            InitLate();
            if (!Rotate.CheckDistacneToTarget(10f)) return;
            if (_mpStat.GetCurrentStatValue() <20) return;
            _mpStat.SubCurrentStateValue(20);
            StartCoroutine(Rotate.Rotate());
            ArrowSplash.gameObject.SetActive(true);
            Enegy.gameObject.SetActive(true);
            ArrowSplash.Play();
            Enegy.Play();
            Invoke(nameof(IceShootTarget), Enegy.duration);
        }

        void IceShootTarget()
        {

            ArrowIceAttack.transform.parent = null;
            ArrowIceAttack.transform.position = new Vector3(Rotate.Target.position.x,1,Rotate.Target.position.z);
            ArrowIceAttack.gameObject.SetActive(true);
            ArrowIceAttack.Play();
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
