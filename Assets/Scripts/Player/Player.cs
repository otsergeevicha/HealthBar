using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<float, float> HealthChanged;
    public const int Died = 0;
    private float _maxHealth = 100;
    private float _health = 100;

    public void Damage(float damageAmount)
    {
        TakeDamage(damageAmount);
    }

    public void Heal(float healAmount)
    {
        TakeHeal(healAmount);
    }

    private void TakeHeal(float heal)
    {
        _health += heal;
        _health = CheckingValue();
        HealthChanged?.Invoke(_health, _maxHealth);
    }

    private void TakeDamage(float damage)
    {
        _health -= damage;
        _health = CheckingValue();
        HealthChanged?.Invoke(_health, _maxHealth);
    }

    private float CheckingValue()
    {
        _health = Mathf.Clamp(_health, Died, _maxHealth);
        return _health;
    }
}