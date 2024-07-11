using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewFraction", menuName = "Data/Fraction")]
public class Fraction : ScriptableObject
{
    [SerializeField] private List<Fraction> _enemyFractions;

    public bool IsEnemy(Fraction fraction) => _enemyFractions.Contains(fraction);
}
