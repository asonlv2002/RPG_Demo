using UnityEngine;
public class CamerFollowPlayer : MonoBehaviour
{
    [SerializeField] Camera _camera;
    PlayerInput _playerInput;
    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.CameraControl.Enable();
    }

    private void OnDisable()
    {
        _playerInput.CameraControl.Disable();
    }
}
