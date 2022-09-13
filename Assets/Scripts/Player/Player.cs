using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<float> HealthChanged;
    private float _health = 100;

    public void TryGiveDamage(float damageAmount)
    {
        if ( _health > 0 && _health >= damageAmount)
        {
            TakeDamage(damageAmount);
        }

        if ( _health < damageAmount )
        {
            _health = 0;
        }
    }
    
    public void TryGiveHeal(float healAmount)
    {
        if ( _health != 0 )
        {
            TakeHeal(healAmount);
        }
    }
    
    private void TakeHeal(float heal)
    {
        _health += heal;
        HealthChanged?.Invoke(_health);
    }
    
    private void TakeDamage(float damage)
    {

        _health -= damage;
        HealthChanged?.Invoke(_health);
    }
}