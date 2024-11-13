using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class Character : MonoBehaviour
{
	public event Action<Character> OnDeath;

	[SerializeField]
	private CharacterBase _characterBase;
	public CharacterBase CharacterBase => _characterBase;

	[SerializeField]
	private CharacterStats _stats;
	public CharacterStats Stats => _stats;

	[SerializeField]
	private bool _isEnemy;
	public bool IsEnemy => _isEnemy;
}
