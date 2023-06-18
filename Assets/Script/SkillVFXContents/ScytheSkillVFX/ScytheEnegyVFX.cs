using AnimatorContent;
using StatContents;
using UnityEngine;
using System.Collections;

namespace SkillVFXContents
{
    internal class ScytheEnegyVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem EnegyAttack;
        [SerializeField] ParticleSystem DarkZone;
        [SerializeField] RotateToTarget _rotate;
        [SerializeField] Transform _character;
        [SerializeField] float high;
        private MPStat _mpStat;
        void SummonEnegy()
        {
            InitLate();
            if (!_rotate.CheckDistacneToTarget(15f)) return;
            if (_mpStat.GetCurrentStatValue() < 20) return;
            StartCoroutine(UseMP());
            StartCoroutine(_rotate.Rotate());
            EnegyAttack.Play();
            EnegyAttack.transform.parent = null;
            var position = _rotate.Target.position;
            position.y = high;
            EnegyAttack.transform.position = position;


            EnegyAttack.gameObject.SetActive(true);
        }

        void EndEnegy()
        {
            StopCoroutine(UseMP());
            EnegyAttack.Stop();
            EnegyAttack.gameObject.SetActive(false);
        }

        void OpenDarkZone()
        {
            DarkZone.Play();
            DarkZone.transform.parent = null;
            var position = _character.position;
            position.y = 2f;
            DarkZone.transform.position = position;
            DarkZone.gameObject.SetActive(true);
        }

        void CloseDarkZone()
        {
            DarkZone.Stop();
            DarkZone.gameObject.SetActive(false);
  
        }

        void InitLate()
        {
            if(_mpStat == null)
            {
                _mpStat = GetComponent<AnimatorCore>().MainCores.GetCore<StatCore>().GetContentComponent<MPStat>();
            }
        }

        IEnumerator UseMP()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                _mpStat.SubCurrentStateValue(20);
                if (_mpStat.GetCurrentStatValue() < 20)
                {
                    EndEnegy();
                    yield break;
                }
            }
        }
    }
}
