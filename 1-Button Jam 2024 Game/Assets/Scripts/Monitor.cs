using UnityEngine;

public class Monitor : MonoBehaviour
{
    private MeshRenderer _renderer => GetComponent<MeshRenderer>();
    private Material _outlineMaterial => _renderer.materials[1];
    private MaterialPropertyBlock _enableOutlinePropertyBlock;

    public bool HasPopUp;

    private void Awake()
    {
        _enableOutlinePropertyBlock = new MaterialPropertyBlock();
    }

    public void Select()
    {
        _enableOutlinePropertyBlock.SetFloat("_Enable_Outline", 1f);
        _renderer.SetPropertyBlock(_enableOutlinePropertyBlock, 1);
    }

    public void Deselect()
    {
        _enableOutlinePropertyBlock.SetFloat("_Enable_Outline", 0f);
        _renderer.SetPropertyBlock(_enableOutlinePropertyBlock, 1);
    }

    public void Interact()
    {
        if (HasPopUp)
        {
            Destroy(transform.GetChild(0).GetChild(transform.GetChild(0).childCount - 1).gameObject);
            HasPopUp = false;
        }
    }
}