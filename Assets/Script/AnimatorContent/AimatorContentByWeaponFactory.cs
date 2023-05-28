using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimatorContent
{
    using Item.ItemGameData;
    internal abstract class AimatorContentByWeaponFactory<T> where T : AnimatorComponent
    {
        public abstract T Factory(WeaponData weaponData);
    }
}
