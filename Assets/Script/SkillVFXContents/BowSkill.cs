namespace SkillVFXContents
{
    using System.Collections;
    using UnityEngine;
    internal class BowSkill : SkillVFX
    {
        [SerializeField] Vector3 posSpawn;
        [SerializeField] Vector3 angle;
        [SerializeField] GameObject Skill;
        [SerializeField] Transform playerTransForm;
        [Header(" ===Aim Shoot===")]
        [SerializeField] Transform FirePoint;
        [SerializeField] GameObject Enegy;
        [SerializeField] GameObject Trails;
        [SerializeField] GameObject ShokcWave;
        [SerializeField] GameObject ProjectTile;
        [SerializeField] Transform target;
        [Header(" ===Purple Arrow ===")]
        [SerializeField] GameObject PurpleEnery;
        [SerializeField] GameObject ArrowPurple;
        [SerializeField] GameObject PurpleArrowAttack;

        public void ArrowFire()
        {
            var skill = Instantiate(Skill, playerTransForm);
            skill.transform.forward = playerTransForm.forward;
            skill.transform.position = posSpawn + playerTransForm.position;
            skill.transform.localEulerAngles = angle;
            skill.transform.SetParent(null);
            Destroy(skill, 2);
        }

        public void AimShoot()
        {
            StartCoroutine(RotateToTarget(1, target.position));
            Enegy.GetComponent<ParticleSystem>().Play();
            Trails.GetComponent<ParticleSystem>().Play();
            ShokcWave.GetComponent<ParticleSystem>().Play();
            StartCoroutine(Attack());
        }

        public void PurpleArrow()
        {
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

        IEnumerator Attack()
        {
            yield return new WaitForSeconds(1.45f);
            GameObject projectile = Instantiate(ProjectTile, FirePoint.position, FirePoint.rotation);
            projectile.GetComponent<TargetProjectile>().UpdateTarget(target, Vector3.zero);
        }

        IEnumerator AttackPurpleArrow()
        {
            yield return new WaitForSeconds(1.2f);
            PurpleArrowAttack.transform.parent = null;
            PurpleArrowAttack.transform.position = target.position;
            PurpleArrowAttack.GetComponent<ParticleSystem>().Play();
        }
    }
}
