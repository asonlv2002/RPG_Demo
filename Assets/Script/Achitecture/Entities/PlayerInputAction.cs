using UnityEngine;

namespace InputContent
{
    using System.Collections.Generic;
    using InputContent;
    using Equipments;
    using Item.ItemGameData;
    using System;
    using Entities;

    internal class PlayerInputAction : Entities.BranchContent,IEquipWeaponSubscriber,IInputContent
    {
        private List<InputComponent> _inputComponents;
        [SerializeField] InputMovement _inputMovement;

        public override void InitMainContent(PlayerRootContent mainContent)
        {
            base.InitMainContent(mainContent);
            _inputComponents = new List<InputComponent>();
            _inputMovement = new InputMovement(new PlayerInput());
            AddContentComponent(_inputMovement);
        }
        public void OnEquipWeapon()
        {
        }

        public T GetContentComponent<T>() where T : InputComponent
        {
            foreach(var component in _inputComponents)
            {
                if (component is T)
                    return component as T;
            }
            return null;
        }

        public void AddContentComponent(InputComponent component)
        {
            _inputComponents.Add(component);
        }

    }
}
