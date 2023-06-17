namespace SkillVFXContents
{
    using System.Collections;
    using UnityEngine;
    internal class BowPurpleSkill : SkillVFX
    {
        [SerializeField] Transform playerTransForm;
        [SerializeField] Transform FirePoint;
        [SerializeField] RotateToTarget Target;
        [Header(" ===Purple Arrow ===")]
        [SerializeField] GameObject PurpleEnery;
        [SerializeField] GameObject ArrowPurple;
        [SerializeField] GameObject PurpleArrowAttack;
        private void Start()
        {
            PurpleEnery.SetActive(false);
            ArrowPurple.SetActive(false);
        }
        void PurpleArrow()
        {
            if (!Target.CheckDistacneToTarget(10f)) return;
            PurpleEnery.SetActive(true);
            ArrowPurple.SetActive(true);
            StartCoroutine(Target.Rotate());
            PurpleEnery.GetComponent<ParticleSystem>().Play();
            ArrowPurple.GetComponent<ParticleSystem>().Play();
            Invoke(nameof(AttackPurpleArrow), 1.2f);
        }
        void AttackPurpleArrow()
        {
            PurpleArrowAttack.SetActive(true);
            PurpleArrowAttack.transform.parent = null;
            PurpleArrowAttack.transform.position = Target.Target.position;
            PurpleArrowAttack.GetComponent<ParticleSystem>().Play();
        }
    }
}
