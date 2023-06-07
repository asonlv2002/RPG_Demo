using UnityEngine;
namespace Achitecture
{
    internal class CharacterSingletonIntance : MonoBehaviour
    {
        public static CharacterSingletonIntance Instance;
        [field : SerializeField] public MainCores MainCore { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
