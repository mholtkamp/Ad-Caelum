using UnityEngine;
using System.Collections;

public class Charge : Spell {
	
	public Charge()
	{
		texture = (Texture) Resources.Load ("Charge");
		activationPrefab = (GameObject) Resources.Load ("ChargeActivationPrefab");
	}
	
	//override
	public override void activate()
	{
		UnityEngine.MonoBehaviour.print("CHARGE");
		Object.Instantiate(activationPrefab);
	}
}
