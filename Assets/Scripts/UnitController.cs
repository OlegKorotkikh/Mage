using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Damageable), typeof(Moveable), typeof(MeleeWrapper))]
public class UnitController : MonoBehaviour
{
    [SerializeField] private float _stopTime = 1f;
    public Transform Target { get; set; }

    [NonSerialized] public Damageable Damageable;
    private Moveable _moveable;
    private MeleeWrapper _meleeWrapper;

    private bool _isStop;

    private void Awake()
    {
        Damageable = GetComponent<Damageable>();
        _moveable = GetComponent<Moveable>();
        _meleeWrapper = GetComponent<MeleeWrapper>();
    }

    private void Start()
    {
        Damageable.Death += OnDeath;
    }

    private void Update()
    {
        if (_isStop) return;

        if (!Target) return;
        
        _moveable.Movement = (Target.position - transform.position).normalized;
        _moveable.Rotation = Quaternion.LookRotation(Target.position - transform.position);
    }

    public void Setup(UnitData unitData, Fraction fraction)
    {
        Damageable.Setup(unitData.Health, unitData.Armor);
        _moveable.Setup(unitData.Speed);
        _meleeWrapper.Setup(unitData.Damage, fraction);
        _meleeWrapper.Attack += OnAttack;
        Instantiate(unitData.Model.ModelPrefab, transform);
    }

    private void OnDeath()
    {
        Damageable.Death -= OnDeath;
        Destroy(gameObject);
    }

    private void OnAttack()
    {
        //for gameplay purposes
        StartCoroutine(StopUnitCoroutine());
    }

    private IEnumerator StopUnitCoroutine()
    {
        _isStop = true;
        _meleeWrapper.enabled = false;
        _moveable.Movement = Vector3.zero;
        yield return new WaitForSeconds(_stopTime);
        _isStop = false;
        _meleeWrapper.enabled = true;
    }
}
