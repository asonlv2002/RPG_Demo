namespace MenuScene
{
    using UnityEngine;
    internal class NamePlayer
    {
        public static NamePlayer Instance;
        string _namePlayer;
        public NamePlayer()
        {
            if(Instance == null) Instance = this;
        }


        public void SetName(string name)
        {
            _namePlayer = name;
            Debug.Log("SetName");
        }
        public string GetName() => _namePlayer;
    }
}
