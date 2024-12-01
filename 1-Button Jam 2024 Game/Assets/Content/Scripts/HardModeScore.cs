using TMPro;

public class HardModeScore : SingletonMono<HardModeScore>
{
    private int _score;

    private TextMeshPro _scoreTMPro => GetComponent<TextMeshPro>();

    public void UpdateScore()
    {
        _score++;
        _scoreTMPro.text = $"{_score}";
    }
}