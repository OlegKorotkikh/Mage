using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float angularSpeed;
    private InputManager inputManager => InputManager.Instance;
    private Damageable _damageable;

    [SerializeField] private GameObject _restartScreen; 
    
    private void Awake()
    {
        _damageable = GetComponent<Damageable>();
    }

    private void Start()
    {
        _damageable.Death += ShowRestartScreen;
    }

    private void Update()
    {
        var movement = inputManager.Movement * Time.deltaTime * speed;
        transform.Translate(Vector3.forward * movement);
        var rotation = inputManager.Rotation * Time.deltaTime * angularSpeed;
        transform.RotateAround(transform.position, Vector3.up, rotation);
    }

    private void ShowRestartScreen()
    {
        _restartScreen.SetActive(true);
        Destroy(gameObject);
    }
}
