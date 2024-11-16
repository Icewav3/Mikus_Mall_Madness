using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miku_VisualsController : MonoBehaviour
{
    [SerializeField]
	private SpriteRenderer charSprite;
    //[VFX]
    [SerializeField]
    private ParticleSystem stageLights;
    [SerializeField]
    private ParticleSystem tinySparks;
    [SerializeField]
    private ParticleSystem point;

    public void ult_StageLights()
	{
		stageLights.Play();
	}

    public void ult_TinySparks()
	{
		tinySparks.Play();
	}

    public void atk2_Point()
	{
		point.Play();
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
