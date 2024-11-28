using UnityEngine;

public class InputManager : SingletonMono<InputManager>
{
    private static InputSystem_Actions _playerActions;

    protected override void Awake()
    {
        base.Awake();

        _playerActions = new InputSystem_Actions();

        Cursor.lockState = CursorLockMode.Locked;

        DontDestroyOnLoad(gameObject);
    }

    #region Core Methods

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