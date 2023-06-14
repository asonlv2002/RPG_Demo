namespace SkillVFXContents
{
    using UnityEngine;
    internal class TriggerBowSkillVFX : MonoBehaviour
    {
        [SerializeField] BowPurpleSkill BowSkill;

        void PurpleArrow()
        {
            BowSkill.PurpleArrow();
        }
    }
}
