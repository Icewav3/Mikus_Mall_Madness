using UnityEngine;

public class RinLen_VisualsController : VisualsController
{
	[SerializeField]
	private SpriteRenderer _charSprite;
	[SerializeField]
	private SpriteRenderer _charSprite2;
	//[VFX]

	public void changeSortingLayerUP()
	{
		_charSprite.sortingLayerName = "CharacterInUse";
		_charSprite2.sortingLayerName = "CharacterInUse";
		print("Called. Current Layer: " + _charSprite.sortingLayerName);
		print("Called. Current Layer: " + _charSprite2.sortingLayerName);
	}
	public void changeSortingLayerDOWN()
	{
		_charSprite.sortingLayerName = "Characters";
		_charSprite2.sortingLayerName = "Characters";
		print("Called. Current Layer: " + _charSprite.sortingLayerName);
		print("Called. Current Layer: " + _charSprite2.sortingLayerName);
	}
}