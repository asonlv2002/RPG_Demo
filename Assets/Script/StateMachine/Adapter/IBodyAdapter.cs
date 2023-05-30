namespace StateContents
{
    internal interface IBodyAdapter
    {
        bool IsTerrestrial { get; }
        bool IsOnGround { get; }

        float FLoatDirection { get; }
        float AngleFeetGround { get; }
        UnityEngine.Transform PlayerTransform { get; }
    }
}
