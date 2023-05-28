﻿using UnityEngine;
namespace AnimatorContent
{
    internal class ScytheAttackParameter : AnimatorComponent, IScytheAttackParameter
    {
        public int AttackE => Animator.StringToHash("AttackE");

        public int AttackQ => Animator.StringToHash("AttackQ");
    }
}
