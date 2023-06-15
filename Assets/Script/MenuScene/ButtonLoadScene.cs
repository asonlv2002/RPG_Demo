
using UnityEngine;
using UnityEngine.UI;

namespace MenuScene
{
    internal class ButtonLoadScene : MonoBehaviour
    {
        Button _onclick;
        [SerializeField] string _nameScene;
        [SerializeField] float _timeLoad;
        [SerializeField] float _timeConvert;



        private void Awake()
        {
            _onclick = GetComponent<Button>();
            _onclick.onClick.AddListener(() =>
            {
                LoadSceneManager.Instance.SetTimeLoad(_timeLoad);
                LoadSceneManager.Instance.SetTimeConver(_timeConvert);
                LoadSceneManager.Instance.EnterLoad(_nameScene);
            });
        }

        private void OnDestroy()
        {
            _onclick.onClick.RemoveAllListeners();
        }
    }
}
