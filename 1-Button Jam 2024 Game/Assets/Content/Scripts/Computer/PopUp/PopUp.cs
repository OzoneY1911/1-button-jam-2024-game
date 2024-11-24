using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private Computer _computer => Computer.Instance;
    private PopUpController _popUpController => PopUpController.Instance;

    private PopUpType _type;
    private Image _image => GetComponent<Image>();
    private Coroutine _vanishCoroutine;

    private void OnEnable()
    {
        _type = (PopUpType)Random.Range(0, 2);
        switch (_type)
        {
            case PopUpType.Virus:
                _image.sprite = _popUpController.VirusSprites[Random.Range(0, _popUpController.VirusSprites.Length)];
                break;
            case PopUpType.Antivirus:
                _image.sprite = _popUpController.AntivirusSprites[Random.Range(0, _popUpController.AntivirusSprites.Length)];
                break;
        }
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
        if (_type == PopUpType.Virus)
        {
            _computer.Damage(20);
        }

        gameObject.SetActive(false);
    }

    public void Close()
    {
        if (_type == PopUpType.Antivirus)
        {
            _computer.Recover(20);
        }

        gameObject.SetActive(false);
    }

    private IEnumerator VanishCooldown()
    {
        yield return new WaitForSecondsRealtime(_lifeTime);
        Vanish();
    }
}