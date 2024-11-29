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

    public void Emerge(in Sprite[] vSprites, in Sprite[] avSprites)
    {
        gameObject.SetActive(true);
        RandomizePosition();

        if (Random.Range(0, 10) > 6)
        {
            _type = PopUpType.Antivirus;
        }
        else
        {
            _type = PopUpType.Virus;
        }

        switch (_type)
        {
            case PopUpType.Virus:
                _image.sprite = vSprites[Random.Range(0, vSprites.Length)];
                break;
            case PopUpType.Antivirus:
                _image.sprite = avSprites[Random.Range(0, avSprites.Length)];
                break;
        }
        _vanishCoroutine = StartCoroutine(VanishCooldown());
    }

    private void RandomizePosition()
    {
        Vector3 randomPos = new Vector3(Random.Range(-.275f, .275f), Random.Range(-.2f, .2f), 0f);
        transform.localPosition = randomPos;
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