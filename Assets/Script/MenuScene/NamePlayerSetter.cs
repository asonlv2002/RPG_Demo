using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace MenuScene
{
    internal class NamePlayerSetter : MonoBehaviour
    {
        NamePlayer namePlayer;
        [SerializeField] TMP_InputField nameField;


        private void Awake()
        {
            namePlayer = new NamePlayer();
        }
        public void SetName()
        {
            namePlayer.SetName(nameField.text);
        }
    }
}
