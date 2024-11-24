using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    private int _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void Damage(in int damagePoints)
    {
        _health -= damagePoints;
    }

    public void Recover(in int healthPoints)
    {
        _health += healthPoints;

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }
}