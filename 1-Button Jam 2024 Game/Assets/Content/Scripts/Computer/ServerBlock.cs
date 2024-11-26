using UnityEngine;

public class ServerBlock : MonoBehaviour
{
    [SerializeField] private float _plugSpeed = .1f;
    [SerializeField] private float _targetZ = -.22f;

    private MeshRenderer _indicatorRenderer;
    private MaterialPropertyBlock _indicatorBlock;
    private bool _indicatorIsGreen = true;

    private float _initialZ;
    private bool _plugInTrigger;
    private bool _plugOutTrigger;

    public bool PlugInTrigger { set { _plugInTrigger = value; } }
    public bool PlugOutTrigger { set { _plugOutTrigger = value; } }

    private void Awake()
    {
        _indicatorBlock = new MaterialPropertyBlock();
        _indicatorRenderer = GetComponent<MeshRenderer>();
        _initialZ = transform.localPosition.z;
    }

    private void Update()
    {
        if (_plugOutTrigger)
        {
            if (_indicatorIsGreen)
            {
                _indicatorIsGreen = false;
                ChangeIndicatorColor(Color.red, _indicatorBlock, 1);
            }

            PlugOut();
        }

        if(_plugInTrigger)
        {
            if (!_indicatorIsGreen)
            {
                _indicatorIsGreen = true;
                ChangeIndicatorColor(new Color(0.66f, 1f, 0f), _indicatorBlock, 1);
            }

            PlugIn();
        }
    }

    private void PlugOut()
    {
        if (transform.localPosition.z <= _targetZ || _plugInTrigger)
        {
            _plugOutTrigger = false;
            return;
        }

        transform.Translate(_plugSpeed * Vector3.up * Time.deltaTime);
    }

    private void PlugIn()
    {
        if (transform.localPosition.z >= _initialZ || _plugOutTrigger)
        {
            _plugInTrigger = false;
            return;
        }

        transform.Translate(_plugSpeed * Vector3.down * Time.deltaTime);
    }

    private void ChangeIndicatorColor(in Color color, in MaterialPropertyBlock block, in int materialIndex)
    {
        block.SetColor("_BaseColor", color);
        block.SetColor("_EmissionColor", color);
        _indicatorRenderer.SetPropertyBlock(block, materialIndex);
    }
}