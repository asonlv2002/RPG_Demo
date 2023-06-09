namespace ItemInforContents
{
    internal abstract class ListenerContain : ItemInforComponent
    {
        protected ItemInforCores InforCores;
        protected IConvertIttemStationSigner Signer;
        protected ListenerContain(ItemInforCores _core)
        {
            InforCores= _core;
        }

        public virtual void AddListener(IConvertItemStationListener listener)
        {
            Signer.AddConvertItemStation(listener);
        }

        public virtual void RemoveListener(IConvertItemStationListener listener)
        {
            Signer.RemoveConvertItemStation(listener);
        }
    }
}
