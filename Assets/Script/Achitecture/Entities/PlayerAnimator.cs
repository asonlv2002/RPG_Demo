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
        private List<AnimatorComponent> _animatorComponents;
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimatorAttackControllerFactory _animatorControllerFactory;
        private AnimationAttackParameterFactory _parameterFactory;
        [SerializeField] RuntimeAnimatorController movement;
        public Type WeaponType { get; private set; }
        public Animator Animator => _animator;
        public AnimationIntHashs AnimationIntHashs { get; private set; }
        private void Awake()
        {
            _animatorComponents = new List<AnimatorComponent>();
            AnimationIntHashs = new AnimationIntHashs();
            _parameterFactory = new AnimationAttackParameterFactory();
            _animatorControllerFactory = new AnimatorAttackControllerFactory(_animator);
        }

        public void OnEquipWeapon(WeaponData weaponData)
        {
            if (WeaponType != null && WeaponType == weaponData.GetType()) return;
            _animatorComponents.Clear();
            AddAnimatorComponent(_parameterFactory.Factory(weaponData));
            AddAnimatorComponent(_animatorControllerFactory.Factory(weaponData));
            _animator.runtimeAnimatorController = movement;
        }

        public T GetAimatorComponet<T>() where T : AnimatorComponent
        {
            foreach(var component in _animatorComponents)
            {
                if (component is T) return component as T;
            }
            return null;
        }

        public void AddAnimatorComponent(AnimatorComponent component)
        {
            _animatorComponents.Add(component);
        }




    }
}
