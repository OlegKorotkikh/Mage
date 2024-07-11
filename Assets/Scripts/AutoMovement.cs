using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class AutoMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Moveable _moveable;
    private void Awake()
    {
        _moveable = GetComponent<Moveable>();
    }

    private void Start()
    {
        _moveable.Setup(_speed);
        _moveable.Movement = transform.forward;
    }
}
