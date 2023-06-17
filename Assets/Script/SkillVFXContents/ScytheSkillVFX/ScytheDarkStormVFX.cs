
using UnityEngine;
using System.Collections;
using StatContents;
using AnimatorContent;

namespace SkillVFXContents
{
    internal class ScytheDarkStormVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem _darkStorm;
        [SerializeField] Transform _characterBody;
        private MPStat _mpStat;

        void DarkStormSummon()
        {
            InitLate();
            if (_mpStat.GetCurrentStatValue() < 20) return;
            _mpStat.SubCurrentStateValue(20);
            _darkStorm.Play();
            _darkStorm.gameObject.SetActive(true);
        }
        IEnumerator FollowPlayer()
        {
            while(true)
            {
                if(_darkStorm.isStopped)
                {
                    yield return null;
                }
                _darkStorm.transform.position = Vector3.Lerp(_darkStorm.transform.position, _characterBody.position, Time.deltaTime * 10f);
            }
        }
        void StopDarkStorm()
        {
            _darkStorm.gameObject.SetActive(false);
            _darkStorm.Stop();
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
