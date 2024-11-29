using Unity.VisualScripting;
using UnityEngine;

public class GameController : SingletonMono<GameController>
{
    [Header("Game Timer")]
    [SerializeField] private Timer _gameTimer;

    [Header("Game End Screens")]
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;

    private bool _gameIsFinished;
    public bool GameIsFinished => _gameIsFinished;

    private void FixedUpdate()
    {
        if (_gameTimer != null)
        {
            if (_gameTimer.TimeLeft <= 0f)
            {
                WinGame();
            }
        }

        if (Computer.Instance.Health == 0)
        {
            LoseGame();
        }
    }

    private void WinGame()
    {
        _winScreen.SetActive(true);
        _gameIsFinished = true;
    }

    private void LoseGame()
    {
        _loseScreen.SetActive(true);
        _gameIsFinished = true;
    }
}