using UnityEngine;
using TMPro;
namespace MenuScene
{
    internal class NamePlayerReader : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _name;

        private void Start()
        {
            _name.text = NamePlayer.Instance.GetName();
        }
    }
}
