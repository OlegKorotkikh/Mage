using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpell", menuName = "Data/Spell")]
public class SpellData : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public float Cooldown;
    public float Damage;
}
