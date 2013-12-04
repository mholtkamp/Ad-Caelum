using UnityEngine;
using System.Collections;

public class IceBall : Spell {

	public IceBall()
	{
		texture = (Texture) Resources.Load ("IceBall");
		activationPrefab = (GameObject) Resources.Load ("IceBallActivationPrefab");
	}
	
	//override
	public override void activate()
	{
		UnityEngine.MonoBehaviour.print("ICEBALL");
		Object.Instantiate(activationPrefab);
	}
}
