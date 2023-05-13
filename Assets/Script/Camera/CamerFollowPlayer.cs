using UnityEngine;
public class CamerFollowPlayer : MonoBehaviour
{
    [SerializeField] Camera _camera;
    PlayerInput _playerInput;

    [SerializeField] Transform _targetFollowed;
    [SerializeField] Transform _resultFollow;
    [SerializeField] float CONST_UN_TRASITION;
    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void FixedUpdate()
    {
        OnHandler();
    }
    public void OnHandler()
    {
        _resultFollow.rotation = _targetFollowed.rotation;
        Vector3 vector3 = _targetFollowed.position;
        vector3.y = 0.75f;
        _resultFollow.position = vector3;
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
