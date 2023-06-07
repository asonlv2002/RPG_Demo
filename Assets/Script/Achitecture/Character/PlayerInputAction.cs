using UnityEngine;

namespace InputContents
{
    using System.Collections.Generic;
    using EquipmentContents;

    internal class PlayerInputAction : InputCore, IEquipWeaponSubscriber
    {
        [SerializeField] InputMovement _inputMovement;

        protected override void Awake()
        {
            base.Awake();
            _inputMovement = new InputMovement(new PlayerInput());
            AddContentComponent(_inputMovement);
        }
        public void OnEquipWeapon()
        {
        }



    }
}
