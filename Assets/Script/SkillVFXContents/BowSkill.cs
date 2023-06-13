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
        [Header("Aim Shoot")]
        [SerializeField] Transform FirePoint;
        [SerializeField] GameObject Enegy;
        [SerializeField] GameObject Trails;
        [SerializeField] GameObject ShokcWave;
        [SerializeField] GameObject ProjectTile;
        [SerializeField] Transform target;

        void ArrowFire()
        {
            Debug.Log("ArrowFire");
            var skill = Instantiate(Skill, playerTransForm);
            skill.transform.forward = playerTransForm.forward;
            skill.transform.position = posSpawn + playerTransForm.position;
            skill.transform.localEulerAngles = angle;
            skill.transform.SetParent(null);
            Destroy(skill, 2);
        }

        void AimShoot()
        {
            StartCoroutine(RotateToTarget(1, target.position));
            Enegy.GetComponent<ParticleSystem>().Play();
            Trails.GetComponent<ParticleSystem>().Play();
            ShokcWave.GetComponent<ParticleSystem>().Play();
            StartCoroutine(Attack());
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
    }
}
