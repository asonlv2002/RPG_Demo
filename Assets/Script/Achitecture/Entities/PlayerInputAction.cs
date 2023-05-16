using UnityEngine;

namespace Input
{
    internal class PlayerInputAction : Entities.BranchContent
    {
        public InputPress InputPress { get; private set; }

        private void Awake()
        {
            InputPress = new InputPress(new PlayerInput());
        }

        private void OnEnable()
        {
            InputPress.EnableInput();
        }

        private void OnDisable()
        {
            InputPress.DisableInput();
        }

    }
}
