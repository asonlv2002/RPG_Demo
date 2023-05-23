namespace Item.InEnviroment
{
    internal class ScytheInEnviroment : WeaponInEnvironment
    {
        private void Start()
        {
            ItemRenderModel = new RenderInEnviroment(this.transform, ItemData.Model);
            ItemRenderModel.RenderModel();
        }
    }
}