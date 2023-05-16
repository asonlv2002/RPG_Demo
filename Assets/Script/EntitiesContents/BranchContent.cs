using UnityEngine;
namespace Entities
{
    internal class BranchContent : MonoBehaviour
    {
        [field: SerializeField] public PlayerRootContent MainContent { get; private set; }

        public virtual void InitMainContent(PlayerRootContent mainContent)
        {
            MainContent = mainContent;
        }
    }
}
