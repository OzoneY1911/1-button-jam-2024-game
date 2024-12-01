using UnityEngine.SceneManagement;

public class LevelLoader : SingletonMono<LevelLoader>
{
    protected override void Awake()
    {
        base.Awake();

        if (UnityEngine.Time.timeScale != 1f)
        {
            UnityEngine.Time.timeScale = 1f;
        }
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}