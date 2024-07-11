using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private UnitData _playerData;
    [SerializeField] private float _speed;
    [SerializeField] private float _angularSpeed;
    [SerializeField] private GameObject _restartScreen;
    
    private Damageable _damageable;
    private Moveable _moveable;
    
    private InputManager InputManager => InputManager.Instance;


    private void Awake()
    {
        _damageable = GetComponent<Damageable>();
        _moveable = GetComponent<Moveable>();
    }

    private void Start()
    {
        _damageable.Setup(_playerData.Health, _playerData.Armor);
        _moveable.Setup(_playerData.Speed);
        _damageable.Death += ShowRestartScreen;
        Instantiate(_playerData.Model.ModelPrefab, transform);
    }

    private void Update()
    {
        var movement = InputManager.Movement;
        var rotation = InputManager.Rotation * _angularSpeed;

        _moveable.Movement = movement * transform.forward;
        _moveable.Rotation = transform.rotation * Quaternion.AngleAxis(rotation, Vector3.up);
    }

    private void ShowRestartScreen()
    {
        _restartScreen.SetActive(true);
        Destroy(gameObject);
    }
}
