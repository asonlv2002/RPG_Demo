namespace StateContents
{
    internal interface IInputMovementAdapter
    {
        bool IsRunPressed { get; }
        bool IsJumpPressed { get; }
        bool IsSpintPressed { get; }

        UnityEngine.Vector3 CurrentInputMovement { get; }

    }
}
