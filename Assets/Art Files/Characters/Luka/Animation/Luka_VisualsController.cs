using UnityEngine;

public class Luka_VisualsController : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _charSprite;
	//[VFX]
	[SerializeField]
	private ParticleSystem _ultInitialSpin;
	[SerializeField]
	private ParticleSystem _ultBigSpin;
	[SerializeField]
	private ParticleSystem _atkSlash;

	public void ultPhase1Spin()
	{
		_ultInitialSpin.Emit(3);
	}

	public void ultPhase2Spin()
	{
		_ultBigSpin.Emit(5);
	}

	public void atkSlash()
	{
		_atkSlash.Play();
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