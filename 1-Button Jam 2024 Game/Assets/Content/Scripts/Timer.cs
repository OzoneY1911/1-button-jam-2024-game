using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _startTimeInMinutes = 5f;

    private float _timeLeft;
    private TextMeshPro _timerTMPro => GetComponent<TextMeshPro>();

    private void Awake()
    {
        _timeLeft = _startTimeInMinutes * 60f;
    }

    private void FixedUpdate()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.fixedDeltaTime;
            UpdateTimer(_timeLeft);
        }
        else
        {
            _timeLeft = 0;
        }
    }

    private void UpdateTimer(float currentTime)
    {
        currentTime++;

        float minutes = Mathf.FloorToInt(currentTime / 60f);
        float seconds = Mathf.FloorToInt(currentTime % 60f);

        if (seconds > 9)
        {
            _timerTMPro.text = $"{minutes}:{seconds}";
        }
        else
        {
            _timerTMPro.text = $"{minutes}:0{seconds}";
        }
    }
}