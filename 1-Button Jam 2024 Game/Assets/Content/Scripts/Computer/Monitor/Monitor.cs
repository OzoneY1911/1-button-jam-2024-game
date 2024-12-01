using UnityEngine;

public class Monitor : MonoBehaviour
{
    [SerializeField] private MeshRenderer _indicatorRenderer;
    [SerializeField] private GameObject _popUpObject;

    public GameObject PopUpObject => _popUpObject;
    public PopUp PopUpScript => _popUpObject.GetComponent<PopUp>();
    public bool HasPopUp => _popUpObject.activeSelf;

    private MaterialPropertyBlock _indicator1Block;
    private MaterialPropertyBlock _indicator2Block;

    private void Awake()
    {
        _indicator1Block = new MaterialPropertyBlock();
        _indicator2Block = new MaterialPropertyBlock();
    }

    public void Select()
    {
        ChangeIndicatorColor(Color.red, _indicator1Block, 2);
    }

    public void Deselect()
    {
        ChangeIndicatorColor(new Color(0.66f, 1f, 0f), _indicator1Block, 2);
    }

    public void ClickStart()
    {
        ChangeIndicatorColor(Color.white, _indicator2Block, 1);
    }

    public void ClickEnd()
    {
        ChangeIndicatorColor(new Color(0.66f, 1f, 0f), _indicator2Block, 1);
    }

    public void Click()
    {
        ClickEnd();

        if (HasPopUp)
        {
            PopUpScript.Close();
        }
    }

    private void ChangeIndicatorColor(in Color color, in MaterialPropertyBlock block, in int materialIndex)
    {
        block.SetColor("_BaseColor", color);
        block.SetColor("_EmissionColor", color);
        _indicatorRenderer.SetPropertyBlock(block, materialIndex);
    }
}