using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [SerializeField] protected SpellData _spellData;
    protected Fraction _fraction;

    private float cooldownTimer;

    private void Awake()
    {
        _fraction = GetComponentInParent<FractionWrapper>().Fraction;
    }
    
    public void Cast(SpellCaster caster)
    {
        if (cooldownTimer > 0)
        {
            Debug.Log("Cooldown!");
            return;
        }

        cooldownTimer = _spellData.Cooldown;
        OnCast(caster);
    }

    protected abstract void OnCast(SpellCaster caster);
    
    public void Update()
    {
        if (cooldownTimer <= 0) return;

        cooldownTimer -= Time.deltaTime;
    }
}
