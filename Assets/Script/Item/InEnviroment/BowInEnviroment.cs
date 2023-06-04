namespace Item.InEnviroment
{
    internal class BowInEnviroment : WeaponInEnvironment
    {
        private void Start()
        {
            ItemRenderModel = new RenderInEnviroment(this.transform, ItemData.Model);
            ItemRenderModel.OnEquipWeapon();
        }
    }
}