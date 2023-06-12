namespace AnimatorContent
{
    using System;
    using UnityEngine;
    [System.Serializable]
    internal class AnimatorEnterAnimation : AnimatorComponent
    {
        [SerializeField] AnimatorCore animatorCore;

        public void SetBool(int hash, bool value)
        {
            animatorCore.Animator.SetBool(hash, value);
        }

        public float LengthAction()
        {
             return animatorCore.Animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        }

        public void SetRootMotion(bool value)
        {
            animatorCore.Animator.applyRootMotion = value;
        }

        internal void SetFloat(int hash, float value)
        {
            animatorCore.Animator.SetFloat(hash, value);
        }
    }
}
