using UnityEngine;
using UnityEngine.Serialization;

public class Fireball : Spell
{
    [SerializeField] private DamageWrapper _fireballPrefab;

    protected override void OnCast(SpellCaster caster)
    {
        var fireball = Instantiate(_fireballPrefab, caster.SpellCastPoint.position, caster.SpellCastPoint.rotation);
        fireball.Setup(_spellData.Damage, _fraction);
        fireball.Attack += () => Destroy(fireball.gameObject);
    }
}
