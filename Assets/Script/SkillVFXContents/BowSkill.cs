namespace SkillVFXContents
{
    using UnityEngine;
    internal class BowSkill : SkillVFX
    {
        [SerializeField] Vector3 posSpawn;
        [SerializeField] Vector3 angle;
        [SerializeField] GameObject Skill;
        [SerializeField] Transform playerTransForm;
        void ArrowFire()
        {
            var skill = Instantiate(Skill, playerTransForm);
            skill.transform.forward = playerTransForm.forward;
            skill.transform.position = posSpawn + playerTransForm.position;
            skill.transform.localEulerAngles = angle;
            skill.transform.SetParent(null);
            Destroy(skill, 2);
        }
    }
}
