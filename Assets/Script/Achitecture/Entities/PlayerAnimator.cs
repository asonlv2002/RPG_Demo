using UnityEngine;
namespace AnimatorContent
{
    using AnimatorContent;
    using Equipments;
    using Item.ItemGameData;
    using System;
    using System.Collections.Generic;

    internal class PlayerAnimator : Entities.BranchContent,IEquipWeaponSubscriber,IAnimatorContent
    {
        [field: SerializeField] public Animator Animator { get; private set; }

        private List<AnimatorComponent> _animatorComponents;
        [SerializeField] private AnimatorMovementControllers _animatorMovementControllers;
        [SerializeField] private AnimatorAttackContains _animatorAttackControllers;
        public AnimationIntHashs AnimationIntHashs { get; private set; }

        private void Awake()
        {
            _animatorComponents = new List<AnimatorComponent>();
            AnimationIntHashs = new AnimationIntHashs();
            _animatorComponents.Add(_animatorMovementControllers);
            _animatorComponents.Add(_animatorAttackControllers);
        }

        public void OnEquipWeapon()
        {
            GetContentComponet<MovementController>().EnterMovement();
        }

        public T GetContentComponet<T>() where T : AnimatorComponent
        {
            foreach(var component in _animatorComponents)
            {
                if (component is T) return component as T;
            }
            return null;
        }

        public void AddContentComponent(AnimatorComponent component)
        {
            _animatorComponents.Add(component);
        }




    }
}
