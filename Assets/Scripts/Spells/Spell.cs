using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [SerializeField] protected SpellData _spellData;
    protected Fraction _fraction;

    private float _cooldownTimer;

    private void Awake()
    {
        _fraction = GetComponentInParent<FractionWrapper>().Fraction;
    }
    
    public void Cast(SpellCaster caster)
    {
        if (_cooldownTimer > 0)
        {
            Debug.Log("Cooldown!");
            return;
        }

        _cooldownTimer = _spellData.Cooldown;
        OnCast(caster);
    }

    protected abstract void OnCast(SpellCaster caster);
    
    public void Update()
    {
        if (_cooldownTimer <= 0) return;

        _cooldownTimer -= Time.deltaTime;
    }
}
