using UnityEngine;

public class GameController : SingletonMono<GameController>
{
    [Header("Game Timer")]
    [SerializeField] private Timer _gameTimer;

    [Header("Game End Screens")]
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;

    private bool _gameIsWon;
    private bool _gameIsLost;
    public bool GameIsWon => _gameIsWon;
    public bool GameIsLost => _gameIsLost;

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
        AudioManager.instance.PlayMusic(AudioManager.MusicClips.Challenge);
        Challenge.IsCompleted = true;
        _winScreen.SetActive(true);
        _gameIsWon = true;
        Time.timeScale = 0f;
    }

    private void LoseGame()
    {
        AudioManager.instance.PlayMusic(AudioManager.MusicClips.Challenge);
        _loseScreen.SetActive(true);
        _gameIsLost = true;
        Time.timeScale = 0f;
    }
}