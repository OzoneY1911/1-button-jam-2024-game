using UnityEngine.SceneManagement;

public class LevelLoader : SingletonMono<LevelLoader>
{
    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}