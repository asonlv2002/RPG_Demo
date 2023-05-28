using UnityEngine;

namespace Input
{
    using InputModify;
    using Equipments;
    using Item.ItemGameData;
    using System;

    internal class PlayerInputAction : Entities.BranchContent,IEquipWeaponSubscriber,IInputAttackProvider
    {
        public InputPress InputPress { get; private set; }
        public InputAttack InputAttack { get; private set; }

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

        public void OnEquipWeapon()
        {
            //InputAttack = new InputAttackFactory(weaponData).InputAttack;
        }
    }
}
