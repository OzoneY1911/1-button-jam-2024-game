using UnityEngine;

public class Monitor : MonoBehaviour
{
    [SerializeField] private MeshRenderer _outlineRenderer;
    [SerializeField] private GameObject _popUp;

    public GameObject PopUp => _popUp;

    private Material _outlineMaterial => _outlineRenderer.materials[1];
    private MaterialPropertyBlock _enableOutlinePropertyBlock;

    public bool HasPopUp;

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

    public void Interact()
    {
        if (HasPopUp)
        {
            _popUp.SetActive(false);
            HasPopUp = false;
        }
    }
}