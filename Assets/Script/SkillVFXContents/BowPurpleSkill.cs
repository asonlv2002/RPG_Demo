namespace SkillVFXContents
{
    using AnimatorContent;
    using StatContents;
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
        private MPStat _mpStat;

        private void Start()
        {
            PurpleEnery.SetActive(false);
            ArrowPurple.SetActive(false);
        }
        void PurpleArrow()
        {
            InitLate();
            if (!Target.CheckDistacneToTarget(10f)) return;
            if (_mpStat.GetCurrentStatValue() < 20) return;
            _mpStat.SubCurrentStateValue(20);
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

        void InitLate()
        {
            if (_mpStat == null)
            {
                _mpStat = GetComponent<AnimatorCore>().MainCores.GetCore<StatCore>().GetContentComponent<MPStat>();
            }
        }
    }
}
