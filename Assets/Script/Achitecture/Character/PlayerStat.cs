
using Achitecture;
using UnityEngine;
namespace StatContents
{
    internal class PlayerStat : StatCore
    {
        [SerializeField] HPStat HP;
        [SerializeField] MPStat MP;
        [SerializeField] SPEEDStat SPEED;
        [SerializeField] ATKStat ATK;
        [SerializeField] DEFStat DEF;
        [SerializeField] HealHpPerSecond HealHpPerSecond;
        [SerializeField] HealMpPerSecond HealMpPerSecond;
        [SerializeField] int value;
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            AddContentComponent(HP);
            AddContentComponent(MP);
            AddContentComponent(SPEED);
            AddContentComponent(ATK);
            AddContentComponent(DEF);
            AddContentComponent(HealHpPerSecond);
            AddContentComponent(HealMpPerSecond);

        }
    }
}
