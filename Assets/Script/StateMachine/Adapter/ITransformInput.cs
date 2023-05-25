namespace StateMachine
{
    internal interface ITransformInput
    {
        bool IsRunPressed { get; }
        bool IsJumpPressed { get; }
        bool IsSpintPressed { get; }

        UnityEngine.Vector3 CurrentInputMovement { get; }

    }
}
