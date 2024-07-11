using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFraction", menuName = "Data/Fraction")]
public class Fraction : ScriptableObject
{
    [SerializeField] private List<Fraction> EnemyFractions;

    public bool IsEnemy(Fraction fraction) => EnemyFractions.Contains(fraction);
}
