using System.Collections;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    private Coroutine _vanishCoroutine;

    private void OnEnable()
    {
        _vanishCoroutine = StartCoroutine(VanishCooldown());
    }

    private void OnDisable()
    {
        if (_vanishCoroutine != null)
        {
            StopAllCoroutines();
        }
    }

    private void Vanish()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator VanishCooldown()
    {
        yield return new WaitForSecondsRealtime(_lifeTime);
        Vanish();
    }
}