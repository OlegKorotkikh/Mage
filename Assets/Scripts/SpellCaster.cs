using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public Spell Spell { get; set; }
    public Transform SpellCastPoint;
    
    public void Cast()
    {
        Spell.Cast(this);
    }
}
