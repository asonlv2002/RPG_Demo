using UnityEngine;
namespace EntitiesContents
{
    internal class BranchContent : MonoBehaviour
    {
        [field: SerializeField] public PlayerMainContent MainContent { get; private set; }

        public void InitMainContent(PlayerMainContent mainContent)
        {
            MainContent = mainContent;
        }
    }
}
