using UnityEngine;
namespace AnimatorContent
{
    internal class ScytheAttackParameter : AnimationAttackParameter, IScytheAttackParameter
    {
        public int AttackE => Animator.StringToHash("AttackE");

        public int AttackQ => Animator.StringToHash("AttackQ");
    }
}
