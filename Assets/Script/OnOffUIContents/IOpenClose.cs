namespace OnOffUIContents
{
    internal interface IOpenClose
    {
        bool IsOpen { get; }

        TransfomPresentation TransfomPresentation { get; }

        public void OpenAction();

        public void CloseAction();

        public UnityEngine.Events.UnityAction OnOpenAction { get; set; }
        public UnityEngine.Events.UnityAction OnCloseAction { get; set; }
    }
}
