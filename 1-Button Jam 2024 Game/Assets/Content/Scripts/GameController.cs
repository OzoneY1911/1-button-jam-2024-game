using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Game Timer")]
    [SerializeField] Timer _gameTimer;

    [Header("Game End Screens")]
    [SerializeField] GameObject _winScreen;
    [SerializeField] GameObject _loseScreen;

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
    }

    private void LoseGame()
    {
        _loseScreen.SetActive(true);
    }
}