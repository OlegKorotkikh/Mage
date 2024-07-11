using System;
using UnityEngine;

[RequireComponent(typeof(FractionWrapper))]
public abstract class DamageWrapper : MonoBehaviour
{
    [SerializeField] protected float _damage;

    public FractionWrapper _fractionWrapper;

    public event Action Attack;
    
    private void Awake()
    {
        _fractionWrapper = GetComponent<FractionWrapper>();
    }

    private void OnDestroy()
    {
        Attack = null;
    }

    public void Setup(float damage, Fraction fraction)
    {
        _damage = damage;
        _fractionWrapper.Fraction = fraction;
    }

    protected void DoAttack(Damageable damageable)
    {
        damageable.TakeDamage(_damage);
        Attack?.Invoke();
    }
}
