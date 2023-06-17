using UnityEngine;

namespace SkillVFXContents
{
    internal class ScytheEnegyVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem EnegyAttack;
        [SerializeField] ParticleSystem DarkZone;
        [SerializeField] RotateToTarget _rotate;
        [SerializeField] Transform _character;
        [SerializeField] float high;

        void SummonEnegy()
        {
            if (!_rotate.CheckDistacneToTarget(15f)) return;
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
    }
}
