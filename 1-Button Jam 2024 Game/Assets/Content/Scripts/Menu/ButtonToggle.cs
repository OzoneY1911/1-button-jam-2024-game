using UnityEngine;
using UnityEngine.UI;

public class ButtonToggle : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private bool _isOn;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener( ()=> Toggle(ref _isOn));
    }

    public void Toggle(ref bool value)
    {
        value = !value;
        _target.SetActive(value);
    }
}