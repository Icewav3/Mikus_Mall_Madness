using UnityEngine;

public class Miku_VisualsController : VisualsController
{
	[SerializeField]
	private SpriteRenderer _charSprite;
	//[VFX]
	[SerializeField]
	private ParticleSystem _stageLights;
	[SerializeField]
	private ParticleSystem _tinySparks;
	[SerializeField]
	private ParticleSystem _afterSparks;
	[SerializeField]
	private ParticleSystem _shockwave;

	public void ult_StageLights()
	{
		_stageLights.Play();
	}

	public void ult_Burst()
	{
		_tinySparks.Play();
		_shockwave.Play();
	}

	public void atk2_afterSparks()
	{
		_afterSparks.Play();
	}

	public void changeSortingLayerUP()
	{
		_charSprite.sortingLayerName = "CharacterInUse";
		print("Called. Current Layer: " + _charSprite.sortingLayerName);
	}
	public void changeSortingLayerDOWN()
	{
		_charSprite.sortingLayerName = "Characters";
		print("Called. Current Layer: " + _charSprite.sortingLayerName);
	}
}