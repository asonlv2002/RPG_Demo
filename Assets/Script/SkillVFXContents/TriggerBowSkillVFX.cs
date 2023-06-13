namespace SkillVFXContents
{
    using UnityEngine;
    internal class TriggerBowSkillVFX : MonoBehaviour
    {
        [SerializeField] BowSkill BowSkill;

        //void ArrowFire()
        //{
        //    BowSkill.ArrowFire();
        //}

        void PurpleArrow()
        {
            BowSkill.PurpleArrow();
        }
    }
}
