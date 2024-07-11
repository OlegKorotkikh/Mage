using System;
using UnityEngine;
using UnityEngine.UI;

public class Damageable : MonoBehaviour
{
    [SerializeField] private float Health;
    [SerializeField] private float Armor;

    public event Action Death;

    private void OnDestroy()
    {
        Death = null;
    }

    public void Setup(float health, float armor)
    {
        Health = health;
        Armor = armor;
    }
    
    public void TakeDamage(float damage)
    {
        Health -= damage * (1f - Armor);
        if (Health <= 0)
        {
            Death?.Invoke();
        }
    }
}
