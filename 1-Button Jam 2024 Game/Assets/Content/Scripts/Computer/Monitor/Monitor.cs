using UnityEngine;

public class Monitor : MonoBehaviour
{
    [SerializeField] private MeshRenderer _outlineRenderer;
    [SerializeField] private GameObject _popUpObject;

    public GameObject PopUpObject => _popUpObject;
    public PopUp PopUpScript => _popUpObject.GetComponent<PopUp>();
    public bool HasPopUp => _popUpObject.activeSelf;

    private MaterialPropertyBlock _enableOutlinePropertyBlock;

    private void Awake()
    {
        _enableOutlinePropertyBlock = new MaterialPropertyBlock();
    }

    public void Select()
    {
        _enableOutlinePropertyBlock.SetFloat("_Enable_Outline", 1f);
        _outlineRenderer.SetPropertyBlock(_enableOutlinePropertyBlock, 1);
    }

    public void Deselect()
    {
        _enableOutlinePropertyBlock.SetFloat("_Enable_Outline", 0f);
        _outlineRenderer.SetPropertyBlock(_enableOutlinePropertyBlock, 1);
    }

    public void Click()
    {
        if (HasPopUp)
        {
            PopUpScript.Close();
        }
    }
}