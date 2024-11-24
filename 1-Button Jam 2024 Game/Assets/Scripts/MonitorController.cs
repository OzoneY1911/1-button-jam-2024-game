using UnityEngine;
using System.Collections;

public class MonitorController : MonoBehaviour
{
    [SerializeField] private Monitor[] _monitors;

    public Monitor[] Monitors => _monitors;

    private Monitor _selectedMonitor;
    private int _monitorIndex;

    private Coroutine _clickCoroutine;
    private bool _canSelect = true;

    private void Update()
    {
        if (InputManager.GetPlayerPress())
        {
            _clickCoroutine = StartCoroutine(Interact());
        }

        if (InputManager.GetPlayerRelease() && _canSelect)
        {
            if (_clickCoroutine != null)
            {
                StopCoroutine(_clickCoroutine);
            }
            SwitchMonitor();
        }
    }

    private void SwitchMonitor()
    {
        if (_selectedMonitor != null)
        {
            if (_monitorIndex == 0)
            {
                _monitors[_monitors.Length - 1].Deselect();
            }
            else
            {
                _selectedMonitor.Deselect();
            }
        }
        _selectedMonitor = _monitors[_monitorIndex];
        _selectedMonitor.Select();

        if (_monitorIndex == _monitors.Length - 1)
        {
            _monitorIndex = 0;
        }
        else
        {
            _monitorIndex++;
        }
    }

    private IEnumerator Interact()
    {
        _canSelect = true;

        yield return new WaitForSecondsRealtime(0.25f);

        _canSelect = false;

        yield return new WaitForSecondsRealtime(0.75f);

        if (InputManager.GetPlayerHold())
        {
            _selectedMonitor.Interact();
        }
    }
}