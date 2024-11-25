using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Miku_VisualsController : VisualsController
{
    [SerializeField]
	private SpriteRenderer charSprite;
    //[VFX]
    [SerializeField]
    private ParticleSystem stageLights;
    [SerializeField]
    private ParticleSystem tinySparks;
    [SerializeField]
    private ParticleSystem afterSparks;
    [SerializeField]
    private ParticleSystem shockwave;

    public void ult_StageLights()
	{
		stageLights.Play();
	}

    public void ult_Burst()
	{
		tinySparks.Play();
		shockwave.Play();
	}

    public void atk2_afterSparks()
	{
        afterSparks.Play();
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
