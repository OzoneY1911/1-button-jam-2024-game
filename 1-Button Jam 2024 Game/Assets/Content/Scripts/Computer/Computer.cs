using UnityEngine;
using UnityEngine.UI;

public class Computer : SingletonMono<Computer>
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private int _maxHealth = 100;

    private int _health;

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
    }

    public void Recover(in int healthPoints)
    {
        _health += healthPoints;
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        _healthBar.value = (float)_health / _maxHealth;
    }
}