using System;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    private float _health;
    private float _armor;

    public event Action Death;

    private void OnDestroy()
    {
        Death = null;
    }

    public void Setup(float health, float armor)
    {
        _health = health;
        _armor = armor;
    }
    
    public void TakeDamage(float damage)
    {
        _health -= damage * (1f - _armor);
        if (_health <= 0)
        {
            Death?.Invoke();
        }
    }
}
