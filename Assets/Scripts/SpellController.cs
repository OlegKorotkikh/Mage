using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpellCaster))]
public class SpellController : MonoBehaviour
{
    [SerializeField] private List<Spell> _spellsConfig; 
    
    private SpellCaster _spellCaster;
    private readonly List<Spell> _spells = new();

    private int _currentSpellIndex;
    
    private InputManager InputManager => InputManager.Instance;

    private void Awake()
    {
        _spellCaster = GetComponent<SpellCaster>();
    }

    private void Start()
    {
        _spellsConfig.ForEach(s => _spells.Add(Instantiate(s, transform)));
        
        InputManager.PreviousSpell += OnPreviousSpell;
        InputManager.NextSpell += OnNextSpell;
        InputManager.CastSpell += OnCastSpell;
        
        SelectSpell();
    }

    private void OnDestroy()
    {
        InputManager.PreviousSpell -= OnPreviousSpell;
        InputManager.NextSpell -= OnNextSpell;
        InputManager.CastSpell -= OnCastSpell;
    }

    private void OnPreviousSpell()
    {
        _currentSpellIndex++;
        if (_currentSpellIndex >= _spells.Count) _currentSpellIndex = 0;
        SelectSpell();
    }

    private void OnNextSpell()
    {
        _currentSpellIndex--;
        if (_currentSpellIndex < 0) _currentSpellIndex = _spells.Count - 1;
        SelectSpell();
    }

    private void SelectSpell()
    {
        _spellCaster.Spell = _spells[_currentSpellIndex];
    }

    private void OnCastSpell()
    {
        _spellCaster.Cast();
    }
}
