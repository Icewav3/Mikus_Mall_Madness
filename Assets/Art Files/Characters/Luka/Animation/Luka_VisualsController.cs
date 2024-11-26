using UnityEngine;

public class Luka_VisualsController : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _charSprite;
	//[VFX]

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