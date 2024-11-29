using UnityEngine.SceneManagement;

public class LevelLoader : SingletonMono<LevelLoader>
{
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}