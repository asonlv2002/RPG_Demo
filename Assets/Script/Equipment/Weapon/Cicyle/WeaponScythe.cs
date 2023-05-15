using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Equipments.PositionEquipments;
namespace Equipments.Weapon
{
    internal class WeaponScythe : WeaponInWorldSpace
    {
        private void Start()
        {
            PositionEquipment = new HandRightEquipment(this.transform);
        }
    }
}
