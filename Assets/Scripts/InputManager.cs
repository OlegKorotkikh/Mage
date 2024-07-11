using System;
using UnityEngine;

//One can use new Input System or InControl for example
public class InputManager : MonoBehaviour
{
    [SerializeField] private KeyCode _previousSpellKey;
    [SerializeField] private KeyCode _nextSpellKey;
    [SerializeField] private KeyCode _castSpellKey;
    [SerializeField] private string _rotationAxisName;
    [SerializeField] private string _movementAxisName;
    
    public event Action CastSpell;
    public event Action NextSpell;
    public event Action PreviousSpell;

    public static InputManager Instance;

    public float Movement { get; private set; }
    public float Rotation { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(_previousSpellKey)) PreviousSpell?.Invoke();
        if (Input.GetKeyDown(_nextSpellKey)) NextSpell?.Invoke();
        if (Input.GetKeyDown(_castSpellKey)) CastSpell?.Invoke();

        Movement = Input.GetAxis(_movementAxisName);
        Rotation = Input.GetAxis(_rotationAxisName);
    }
}
