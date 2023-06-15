using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;
namespace MenuScene
{
    internal class LoadSceneManager : MonoBehaviour
    {
        public static LoadSceneManager Instance;
        [SerializeField] GameObject _sceneLoading;
        [SerializeField] Slider _loadBar; 
        [SerializeField] TextMeshProUGUI _loadingText;
        bool _isLoadScene;
        float _timeLoad;
        float _timeConvert;
        int _typeText;

        public void SetTimeLoad(float time) => _timeLoad = time;
        public void SetTimeConver(float time) => _timeConvert = time;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
            _isLoadScene = false;
        }

        public void EnterLoad(string sceneName) 
        {
            _sceneLoading.SetActive(true);
            
            StartCoroutine(Load(sceneName));
        }

        IEnumerator Load(string sceneName)
        {
            var time = _timeLoad;
            while(true)
            {

                if(time < _timeConvert && _isLoadScene == false)
                {
                    LoadSceneSetter(sceneName);
                }
                if (time <= 0)
                {

                    _sceneLoading.SetActive(false);
                    _isLoadScene = false;
                    yield break;
                }
                yield return new WaitForSeconds(0.005f);
                LoadText();
                time -= Time.deltaTime;
                _loadBar.value = 1 - time / _timeLoad;
            }
        }

        void LoadSceneSetter(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            _isLoadScene = true;
        }

        void LoadText()
        {
            _typeText++;
            if(_typeText >2)
            {
                _typeText = 0;
            }
            string text = "";
            switch (_typeText)
            {
                case 0:
                    text = "Loading...";
                    break;
                case 1:
                    text = "Loading..";
                    break;
                case 2:
                    text = "Loading.";
                    break;
            }
            _loadingText.text = text;
        }


    }
}
