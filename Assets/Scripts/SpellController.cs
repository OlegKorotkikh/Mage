using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(SpellCaster))]
public class SpellController : MonoBehaviour
{
    private InputManager inputManager => InputManager.Instance;

    private SpellCaster _spellCaster;
    [SerializeField] private List<Spell> _spellsConfig; 
    private readonly List<Spell> spells = new();

    private int currentSpellIndex;
    private Spell currentSpell => spells[currentSpellIndex];

    private void Awake()
    {
        _spellCaster = GetComponent<SpellCaster>();
    }

    private void Start()
    {
        _spellsConfig.ForEach(s => spells.Add(Instantiate(s, transform)));
        
        inputManager.PreviousSpell += OnPreviousSpell;
        inputManager.NextSpell += OnNextSpell;
        inputManager.CastSpell += OnCastSpell;
        
        SelectSpell();
    }

    private void OnDestroy()
    {
        inputManager.PreviousSpell -= OnPreviousSpell;
        inputManager.NextSpell -= OnNextSpell;
        inputManager.CastSpell -= OnCastSpell;
    }

    private void OnPreviousSpell()
    {
        currentSpellIndex++;
        if (currentSpellIndex >= spells.Count) currentSpellIndex = 0;
        SelectSpell();
    }

    private void OnNextSpell()
    {
        currentSpellIndex--;
        if (currentSpellIndex < 0) currentSpellIndex = spells.Count - 1;
        SelectSpell();
    }

    private void SelectSpell()
    {
        _spellCaster.Spell = spells[currentSpellIndex];
    }

    private void OnCastSpell()
    {
        _spellCaster.Cast();
    }
}
