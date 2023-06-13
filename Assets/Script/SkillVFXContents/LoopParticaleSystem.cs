using System.Collections;
namespace SkillVFXContents
{
    using UnityEngine;
    internal class LoopParticaleSystem : MonoBehaviour
    {
        ParticleSystem _vfx;

        //time less than ParticleSystem.duration
        [SerializeField] float _timeStart;
        [SerializeField] float _timeEnd;
        [SerializeField] bool _endLoop = false;

        private void Awake()
        {
            _endLoop = false;
            _vfx = GetComponent<ParticleSystem>();
        }


        public void SetEndLoop(bool value)
        {
            _endLoop = value;
        }

        public void PlayInLoop()
        {
            _vfx.Play();
            Invoke(nameof(Loop), _timeStart);

        }

        void Loop()
        {
            _vfx.Simulate(_timeStart, true, true);
            _vfx.Play();
            StartCoroutine(Restart());
        }

        IEnumerator Restart()
        {
            if(_endLoop)
            {
                EndLoop();
                yield break;
            }

            yield return new WaitForSeconds(_timeEnd - _timeStart);
            Loop();
        }

        void EndLoop()
        {
            SetEndLoop(false);
            _vfx.Simulate(_timeEnd,true, false);
            _vfx.Play();
        }
    }
}
