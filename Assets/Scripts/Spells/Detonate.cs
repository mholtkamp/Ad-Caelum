using UnityEngine;
using System.Collections;

public class Detonate : Spell{

	public Detonate()
	{
		texture = (Texture) Resources.Load ("Detonate");
		activationPrefab = (GameObject) Resources.Load ("DetonateActivationPrefab");

	}
	
	public override void activate ()
	{
		UnityEngine.MonoBehaviour.print("DETONATE");
		Object.Instantiate(activationPrefab);

	}
	
}
