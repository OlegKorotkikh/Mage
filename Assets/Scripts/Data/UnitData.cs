using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Data/Unit")]
public class UnitData : ScriptableObject
{
    public Model Model;
    public float Speed;
    public float Health;
    public float Damage;
    public float Armor;
}