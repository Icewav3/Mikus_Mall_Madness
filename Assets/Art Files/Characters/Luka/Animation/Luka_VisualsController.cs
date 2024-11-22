using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luka_VisualsController : MonoBehaviour
{
    [SerializeField]
	private SpriteRenderer charSprite;
    //[VFX]
    
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
