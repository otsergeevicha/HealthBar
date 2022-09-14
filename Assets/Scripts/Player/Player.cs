using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<float, float> HealthChanged;
    private float _maxHealth = 100;
    private float _health = 100;

    public void CauseDamage(float damageAmount)
    {
        if ( _health > 0 && _health >= damageAmount )
        {
            TakeDamage(damageAmount);
        }

        if ( _health < damageAmount )
        {
            _health = 0;
        }
    }

    public void CauseHeal(float healAmount)
    {
        if ( _health != 0 && _health != _maxHealth)
        {
            TakeHeal(healAmount);
        }
    }

    private void TakeHeal(float heal)
    {
        _health += heal;
        HealthChanged?.Invoke(_health, _maxHealth);
    }

    private void TakeDamage(float damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health, _maxHealth);
    }
}