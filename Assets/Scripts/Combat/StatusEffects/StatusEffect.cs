using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using UnityEngine;

public class StatusEffect
{
    public StatusEffect(StatusEffectBase effectBase, int duration)
	{
		Base = effectBase;
		Duration = duration;
	}

	public StatusEffectBase Base { get; private set; }
	public ReadOnlyCollection<StatBoost> StatBoosts => Base.StatBoosts;
	public ReadOnlyCollection<StatusEffectProc> Procs => Base.Procs;
	public int Duration { get; private set; }

	public void DecreaseDuration()
	{
		Duration--;
	}

	public void SetDuration(int duration)
	{
		Duration = duration;
	}

	public override bool Equals(object obj)
	{
		StatusEffect other = obj as StatusEffect;
		if (other == null) return false;
		return Base.Equals(other.Base);
	}

	// be proud of me
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
