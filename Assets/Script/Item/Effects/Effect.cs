namespace Item.Effects
{
    using UnityEngine;
    using Achitecture;
    internal abstract class Effect : ScriptableObject
    {
        [SerializeField][TextArea] string _description;
        public string Description => _description;
        public void ActiveEffect()
        {

        }
    }
}
