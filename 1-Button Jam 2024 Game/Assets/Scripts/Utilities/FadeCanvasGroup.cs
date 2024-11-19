using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeCanvasGroup : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    [SerializeField] private float _fadeSpeed = 0.1f;

    private Coroutine _inCoroutine;
    private Coroutine _outCoroutine;

    private bool _fadingIn;
    private bool _fadingOut;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ShowCanvas()
    {
        if (_fadingOut)
        {
            StopCoroutine(_outCoroutine);
            _fadingOut = false;
        }

        _inCoroutine = StartCoroutine(FadeIn());
    }

    public void HideCanvas()
    {
        if (_fadingIn)
        {
            StopCoroutine(_inCoroutine);
            _fadingIn = false;
        }

        _outCoroutine = StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        _fadingIn = true;

        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;

        while (_canvasGroup.alpha != 1f)
        {
            _canvasGroup.alpha += _fadeSpeed;
            yield return null;
        }

        _fadingIn = false;
    }

    private IEnumerator FadeOut()
    {
        _fadingOut = true;

        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;

        while (_canvasGroup.alpha != 0f)
        {
            _canvasGroup.alpha -= _fadeSpeed;
            yield return null;
        }

        _fadingOut = false;
    }
}