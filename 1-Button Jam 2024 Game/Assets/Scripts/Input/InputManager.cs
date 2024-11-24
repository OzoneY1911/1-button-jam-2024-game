using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputSystem_Actions _playerActions;

    #region Core Methods

    private void Awake()
    {
        _playerActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _playerActions.Enable();
    }

    private void OnDisable()
    {
        _playerActions.Disable();
    }

    private void OnDestroy()
    {
        _playerActions.Dispose();
    }

    #endregion

    public static bool GetPlayerPress()
    {
        return _playerActions.Player.Press.WasPressedThisFrame();
    }

    public static bool GetPlayerHold()
    {
        return _playerActions.Player.Press.IsPressed();
    }

    public static bool GetPlayerRelease()
    {
        return _playerActions.Player.Press.WasReleasedThisFrame();
    }
}