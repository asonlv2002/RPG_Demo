namespace SignItemContents
{
    using UnityEngine;
    [System.Serializable]
    internal class OpenCloseSignItems : SignItemComponent
    {
        [SerializeField] SignItemCores SignItemCores;
        public bool IsOpen => SignItemCores.gameObject.activeSelf;

        public void Open()
        {
            if (!IsOpen) SignItemCores.gameObject.SetActive(true);
        }

        public void Close()
        {
            SignItemCores.gameObject.SetActive(false);
        }
    }
}
