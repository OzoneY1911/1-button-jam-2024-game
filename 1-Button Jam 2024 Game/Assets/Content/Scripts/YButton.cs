using UnityEngine;

public class YButton : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
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