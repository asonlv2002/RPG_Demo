
using UnityEngine;
using System.Collections;

namespace ScytheSkillVFX
{
    internal class ScytheDarkStormVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem _darkStorm;
        [SerializeField] Transform _characterBody;
        void DarkStormSummon()
        {
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
    }
}
