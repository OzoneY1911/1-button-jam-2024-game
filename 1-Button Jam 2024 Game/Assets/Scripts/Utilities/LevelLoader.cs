using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : SingletonMono<LevelLoader>
{
    [SerializeField] private GameObject _blackScreen;
    [SerializeField] private GameObject _loadScreen;
    [SerializeField] private Slider _loadSlider;
    [SerializeField] private TextMeshProUGUI _loadText;

    private void Start()
    {
        _blackScreen.GetComponent<FadeCanvasGroup>().HideCanvas();
    }

    public void LoadLevel(string name)
    {
        if (_loadScreen != null)
        {
            StartCoroutine(LoadAsync(name));
        }
        else
        {
            StartCoroutine(Load(name));
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadAsync(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            _loadSlider.value = operation.progress / 0.9f;
            _loadText.text = (int) (100f / 0.9f * operation.progress) + "%";

            if (operation.progress >= 0.9f)
            {
                _loadText.text = "Press SPACE to continue";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine(Load(name, operation));
                }
            }

            yield return null;
        }
    }

    private IEnumerator Load(string name, AsyncOperation operation = null)
    {
        _blackScreen.GetComponent<FadeCanvasGroup>().ShowCanvas();

        while (_blackScreen.GetComponent<CanvasGroup>().alpha != 1f)
        {
            yield return null;
        }

        if (_blackScreen.GetComponent<CanvasGroup>().alpha == 1f)
        {
            if (operation == null)
            {
                SceneManager.LoadScene(name);
            }
            else
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}