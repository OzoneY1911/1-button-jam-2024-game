using UnityEngine;
using UnityEngine.UI;

public class Computer : SingletonMono<Computer>
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private ServerBlock[] _serverBlocks;

    private int _health;
    public int Health => _health;

    protected override void Awake()
    {
        base.Awake();

        _health = _maxHealth;
        UpdateHealthBar();
    }

    public void Damage(in int damagePoints)
    {
        _health -= damagePoints;
        if (_health < 0)
        {
            _health = 0;
        }
        UpdateHealthBar();
        UpdateServerBlocks();
    }

    public void Recover(in int healthPoints)
    {
        _health += healthPoints;
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        UpdateHealthBar();
        UpdateServerBlocks();
    }

    private void UpdateHealthBar()
    {
        _healthBar.value = (float)_health / _maxHealth;
    }

    private void UpdateServerBlocks()
    {
        int firstBrokenBlock = (_health / 10) - 1;
        if (HardModeScore.Instance != null)
        {
            firstBrokenBlock /= 2;
        }

        for (int i = 0; i < _serverBlocks.Length; i++)
        {
            if (i <= firstBrokenBlock)
            {
                _serverBlocks[i].PlugInTrigger = true;
            }
            else
            {
                _serverBlocks[i].PlugOutTrigger = true;
            }
        }
    }
}