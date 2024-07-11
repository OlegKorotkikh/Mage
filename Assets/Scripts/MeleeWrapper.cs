using UnityEngine;

public class MeleeWrapper : DamageWrapper
{
    private void OnTriggerStay(Collider other)
    {
        if (!enabled) return;
        
        if (other.TryGetComponent<Damageable>(out var otherDamageable) && other.TryGetComponent<FractionWrapper>(out var otherFraction))
        {
            if (_fractionWrapper.Fraction.IsEnemy(otherFraction.Fraction))
            {
                DoAttack(otherDamageable);
            }
        }    
    }
}