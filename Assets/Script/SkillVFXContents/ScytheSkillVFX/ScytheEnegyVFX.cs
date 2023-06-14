using UnityEngine;

namespace ScytheSkillVFX
{
    internal class ScytheEnegyVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem EnegyAttack;
        [SerializeField] Transform _target;
        [SerializeField] float high;

        void SummonEnegy()
        {
            EnegyAttack.Play();
            var position = _target.position;
            position.y = high;
            EnegyAttack.transform.position = position;
            EnegyAttack.gameObject.SetActive(true);
        }

        void EndEnegy()
        {
            EnegyAttack.Stop();
            EnegyAttack.gameObject.SetActive(false);
        }
    }
}
