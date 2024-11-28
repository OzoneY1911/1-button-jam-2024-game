using Unity.VisualScripting;
using UnityEngine;

public class YButton : MonoBehaviour
{
    private Animator _animator;

    private bool _initHolding;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        if (InputManager.GetPlayerHold())
        {
            _initHolding = true;
        }
    }

    private void Update()
    {
        if (_initHolding)
        {
            if (InputManager.GetPlayerRelease())
            {
                _initHolding = false;
                return;
            }
            return;
        }

        if (InputManager.GetPlayerPress())
        {
            _animator.SetTrigger("Press");
        }

        if (InputManager.GetPlayerRelease())
        {
            _animator.SetTrigger("Release");
        }
    }
}