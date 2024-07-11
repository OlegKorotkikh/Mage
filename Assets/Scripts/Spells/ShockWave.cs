using UnityEngine;

public class ShockWave : Spell
{
    [SerializeField] private DamageWrapper _shockWavePrefab; 
        
    protected override void OnCast(SpellCaster caster)
    {
        var shockWave = Instantiate(_shockWavePrefab, caster.SpellCastPoint.position, caster.SpellCastPoint.rotation);
        shockWave.Setup(_spellData.Damage, _fraction);
    }
}
