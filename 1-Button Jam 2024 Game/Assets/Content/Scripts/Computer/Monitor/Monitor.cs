using NUnit.Framework.Constraints;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    [SerializeField] private MeshRenderer _indicatorRenderer;
    [SerializeField] private GameObject _popUpObject;

    public GameObject PopUpObject => _popUpObject;
    public PopUp PopUpScript => _popUpObject.GetComponent<PopUp>();
    public bool HasPopUp => _popUpObject.activeSelf;

    private MaterialPropertyBlock _colorPropertyBlock;

    private void Awake()
    {
        _colorPropertyBlock = new MaterialPropertyBlock();
    }

    public void Select()
    {
        _colorPropertyBlock.SetColor("_BaseColor", Color.red);
        _colorPropertyBlock.SetColor("_EmissionColor", Color.red);
        _indicatorRenderer.SetPropertyBlock(_colorPropertyBlock, 1);
    }

    public void Deselect()
    {
        _colorPropertyBlock.SetColor("_BaseColor", new Color(170f, 255f, 0f));
        _colorPropertyBlock.SetColor("_EmissionColor", new Color(170f, 255f, 0f));
        _indicatorRenderer.SetPropertyBlock(_colorPropertyBlock, 1);
    }

    public void Click()
    {
        if (HasPopUp)
        {
            PopUpScript.Close();
        }
    }
}