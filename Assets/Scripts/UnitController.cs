using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Damageable), typeof(Moveable), typeof(MeeleWrapper))]
public class UnitController : MonoBehaviour
{
    [SerializeField] private float _stopTime = 1f;
    public Transform Target { get; set; }

    public Damageable damageable;
    private Moveable moveable;
    private MeeleWrapper _meeleWrapper;

    private bool isStop;

    private void Awake()
    {
        damageable = GetComponent<Damageable>();
        moveable = GetComponent<Moveable>();
        _meeleWrapper = GetComponent<MeeleWrapper>();
    }

    private void Start()
    {
        damageable.Death += OnDeath;
    }

    private void Update()
    {
        if (isStop) return;

        if (!Target) return;
        
        moveable.Movement = (Target.position - transform.position).normalized;
        moveable.Rotation = Quaternion.LookRotation(Target.position - transform.position, Vector3.up);
    }

    public void Setup(UnitData unitData, Fraction fraction)
    {
        damageable.Setup(unitData.Health, unitData.Armor);
        moveable.Setup(unitData.Speed);
        _meeleWrapper.Setup(unitData.Damage, fraction);
        _meeleWrapper.Attack += OnAttack;
        Instantiate(unitData.Model.ModelPrefab, transform);
    }

    private void OnDeath()
    {
        damageable.Death -= OnDeath;
        Destroy(gameObject);
    }

    private void OnAttack()
    {
        //for gameplay purposes
        StartCoroutine(StopUnitCoroutine());
    }

    private IEnumerator StopUnitCoroutine()
    {
        isStop = true;
        _meeleWrapper.enabled = false;
        moveable.Movement = Vector3.zero;
        yield return new WaitForSeconds(_stopTime);
        isStop = false;
        _meeleWrapper.enabled = true;
    }
}
