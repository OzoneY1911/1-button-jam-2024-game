using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MonitorController : SingletonMono<MonitorController>
{
    private Monitor[] _monitors;
    public Monitor[] Monitors => _monitors;

    private Monitor _selectedMonitor;
    private int _monitorIndex;
    private Coroutine _interactCoroutine;
    private bool _canSelect = true;

    protected override void Awake()
    {
        base.Awake();

        if (HardModeScore.Instance == null)
        {
            _monitors = new Monitor[4];
        }
        else
        {
            _monitors = new Monitor[8];
        }

        for (int i = 0; i < _monitors.Length; i++)
        {
            _monitors[i] = transform.GetChild(i).GetComponent<Monitor>();
        }
    }

    private void Update()
    {
        if (InputManager.GetPlayerPress() && _selectedMonitor != null)
        {
            _interactCoroutine = StartCoroutine(Interact());
        }

        if (InputManager.GetPlayerRelease())
        {
            if (_canSelect)
            {
                if (_interactCoroutine != null)
                {
                    StopCoroutine(_interactCoroutine);
                }
                SwitchMonitor();
            }
            else
            {
                if (_selectedMonitor != null)
                {
                    _selectedMonitor.ClickEnd();
                }
            }
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

        _selectedMonitor.ClickStart();

        if (GameController.Instance.GameIsWon || GameController.Instance.GameIsLost)
        {
            yield return new WaitForSecondsRealtime(2f);
            if (InputManager.GetPlayerHold())
            {
                if (GameController.Instance.GameIsWon)
                {
                    LevelLoader.Instance.LoadLevel("MainMenu");
                }
                else if (GameController.Instance.GameIsLost)
                {
                    if (HardModeScore.Instance == null)
                    {
                        LevelLoader.Instance.LoadLevel(SceneManager.GetActiveScene().name);
                    }
                    else
                    {
                        LevelLoader.Instance.LoadLevel("MainMenu");
                    }
                }
            }
        }
        else
        {
            yield return new WaitForSecondsRealtime(0.75f);
            if (InputManager.GetPlayerHold())
            {
                _selectedMonitor.Click();
            }
        }
    }
}