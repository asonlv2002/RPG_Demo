using UnityEngine;

namespace InputContent
{
    using System.Collections.Generic;
    using InputContent;
    using Equipments;
    using Item.ItemGameData;
    using System;

    internal class PlayerInputAction : Entities.BranchContent,IEquipWeaponSubscriber,IInputContent
    {
        private List<InputComponent> _inputComponents;
        [SerializeField] InputMovement _inputMovement;
        IInputAttackScythe inputAttack;

        private void Awake()
        {
            _inputComponents = new List<InputComponent>();
            _inputMovement = new InputMovement();
            AddContentComponent(_inputMovement);
        }
        public void OnEquipWeapon()
        {
            inputAttack = GetContentComponet<InputAttackScyther>();
        }

        public T GetContentComponet<T>() where T : InputComponent
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

        private void Update()
        {
            if(inputAttack != null) Debug.Log(inputAttack.AttackQ);
        }
    }
}
