using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Button _hardModeButton;

    private Coroutine _pressCoroutine;
    private int _buttonIndex;
    private bool _canSelect = true;
    private bool _canPress;

    private void Start()
    {
        if (Challenge.IsCompleted)
        {
            _hardModeButton.interactable = true;
            _hardModeButton.GetComponent<TextMeshProUGUI>().text = "HARD MODE";
        }
    }

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
            MoveToNextButton();
        }
        else
        {
            _canPress = true;
        }

        if (!_buttons[_buttonIndex].interactable)
        {
            MoveToNextButton();
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

    private void MoveToNextButton()
    {
        _buttonIndex++;
        if (_buttonIndex == _buttons.Length)
        {
            _buttonIndex = 0;
        }
    }
}