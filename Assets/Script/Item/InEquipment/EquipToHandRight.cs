using UnityEngine;
namespace Item.InEquipment
{
    internal class EquipToHandRight: EquipPosition, ISetPosition
    {
        private Transform _target;
        private Transform _position;
        public EquipToHandRight(Transform target,IProviderPosition providerPosition) : base(providerPosition)
        {
            _target = target;
            _position = _providerPosition.HandRight();
        }
        public void SetPosition()
        {
            _target.SetParent(_position);
            _target.localPosition = Vector3.zero;
        }
    }
}
