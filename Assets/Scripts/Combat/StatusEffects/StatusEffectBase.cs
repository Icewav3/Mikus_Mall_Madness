using System.Collections.Generic;
using System.Collections.ObjectModel;

using UnityEngine;


[CreateAssetMenu(fileName = "Status Effect Base", menuName = "ScriptableObjects/Status Effects/Status Effect Base")]
public class StatusEffectBase : ScriptableObject
{
	[SerializeField]
	private List<StatBoost> _statBoosts;
	public ReadOnlyCollection<StatBoost> StatBoosts => _statBoosts.AsReadOnly();

	[SerializeField]
	private List<StatusEffectProc> _procs;
	public ReadOnlyCollection<StatusEffectProc> Procs => _procs.AsReadOnly();
}