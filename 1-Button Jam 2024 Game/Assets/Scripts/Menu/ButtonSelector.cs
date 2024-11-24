using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    private Coroutine _pressCoroutine;
    private int _buttonIndex;
    private bool _canSelect = true;
    private bool _canPress;

    private void Update()
    {
        if (InputManager.GetPlayerPress() && _canPress)
        {
            _pressCoroutine = StartCoroutine(PressButton());
        }

        if (InputManager.GetPlayerRelease() && _canSelect)
        {
            if (_pressCoroutine != null)
            {
                StopCoroutine(_pressCoroutine);
            }
            SelectButton();
        }
    }

    private void SelectButton()
    {
        if (_canPress)
        {
            _buttonIndex++;
            if (_buttonIndex == _buttons.Length)
            {
                _buttonIndex = 0;
            }
        }
        else
        {
            _canPress = true;
        }

        _buttons[_buttonIndex].Select();
    }

    private IEnumerator PressButton()
    {
        _canSelect = true;

        yield return new WaitForSecondsRealtime(0.25f);

        _canSelect = false;

        yield return new WaitForSecondsRealtime(0.75f);

        if (InputManager.GetPlayerHold())
        {
            _buttons[_buttonIndex].onClick.Invoke();
        }
    }
}