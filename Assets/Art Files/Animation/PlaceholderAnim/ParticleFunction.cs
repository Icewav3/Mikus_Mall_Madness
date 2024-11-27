using UnityEngine;

public class ParticleFunction : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem atkNormalFX;
	[SerializeField]
	private ParticleSystem atkSpecialFX;
	[SerializeField]
	private SpriteRenderer charSprite;

	// Start is called before the first frame update
	void Start()
	{

	}

	public void atkNormalEmit()
	{
		atkNormalFX.Emit(1);
	}

	public void atkSpecialEmit()
	{
		atkSpecialFX.Emit(1);
	}

	public void changeSortingLayerUP()
	{
		charSprite.sortingLayerName = "CharacterInUse";
		print("Called. Current Layer: " + charSprite.sortingLayerName);
	}
	public void changeSortingLayerDOWN()
	{
		charSprite.sortingLayerName = "Characters";
		print("Called. Current Layer: " + charSprite.sortingLayerName);
	}
}