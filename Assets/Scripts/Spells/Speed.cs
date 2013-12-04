using UnityEngine;
using System.Collections;

public class Speed : Spell {

	public Speed()
	{
		texture = (Texture) Resources.Load ("Speed");
		activationPrefab = (GameObject) Resources.Load ("SpeedActivationPrefab");
	}
	
	//override
	public override void activate()
	{
		UnityEngine.MonoBehaviour.print("SPEED");
		Object.Instantiate(activationPrefab);
	}
}
