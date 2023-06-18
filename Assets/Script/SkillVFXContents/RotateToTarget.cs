using System.Collections;
using UnityEngine;

namespace SkillVFXContents
{
    internal class RotateToTarget : MonoBehaviour
    {
        [field: SerializeField] public Transform Target { get; private set; }
        [field: SerializeField] public Transform Character { get; private set; }

        public IEnumerator Rotate()
        {
            float delay = 1f;
            var lookPos = Target.position - Character.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            while (true)
            {
                Character.rotation = Quaternion.Lerp(Character.rotation, rotation, Time.deltaTime * 20);
                delay -= Time.deltaTime;
                if (delay <= 0 || Character.rotation == rotation)
                {
                    yield break;
                }
                yield return null;
            }
        }

        public bool CheckDistacneToTarget(float maxDistance)
        {
            if (Target == null) return false;
            return Vector3.Distance(Character.position, Target.position) < maxDistance;
        }
    }
}
