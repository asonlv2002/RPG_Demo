namespace SkillVFXContents
{
    using System.Collections;
    using UnityEngine;
    internal class BowPurpleSkill : SkillVFX
    {
        [SerializeField] Transform playerTransForm;
        [SerializeField] Transform FirePoint;
        [SerializeField] Transform target;
        [Header(" ===Purple Arrow ===")]
        [SerializeField] GameObject PurpleEnery;
        [SerializeField] GameObject ArrowPurple;
        [SerializeField] GameObject PurpleArrowAttack;
        private void Start()
        {
            PurpleEnery.SetActive(false);
            ArrowPurple.SetActive(false);
        }
        public void PurpleArrow()
        {
            PurpleEnery.SetActive(true);
            ArrowPurple.SetActive(true);
            StartCoroutine(RotateToTarget(1, target.position));
            PurpleEnery.GetComponent<ParticleSystem>().Play();
            ArrowPurple.GetComponent<ParticleSystem>().Play();
            StartCoroutine(AttackPurpleArrow());
        }

        public IEnumerator RotateToTarget(float rotatingTime, Vector3 targetPoint)
        {
            float delay = rotatingTime;
            var lookPos = targetPoint - playerTransForm.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            while (true)
            {
                playerTransForm.rotation = Quaternion.Lerp(playerTransForm.rotation, rotation, Time.deltaTime * 20);
                delay -= Time.deltaTime;
                if (delay <= 0 || playerTransForm.rotation == rotation)
                {
                    yield break;
                }
                yield return null;
            }
        }

        IEnumerator AttackPurpleArrow()
        {

            yield return new WaitForSeconds(1.2f);
            PurpleArrowAttack.SetActive(true);
            PurpleArrowAttack.transform.parent = null;
            PurpleArrowAttack.transform.position = target.position;
            PurpleArrowAttack.GetComponent<ParticleSystem>().Play();
        }
    }
}
