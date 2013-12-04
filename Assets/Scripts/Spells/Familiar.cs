using UnityEngine;
using System.Collections;

public class Familiar : Spell {

	public Familiar()
	{
		texture = (Texture) Resources.Load ("Familiar");
		activationPrefab = (GameObject) Resources.Load ("FamiliarActivationPrefab");
	}
	
	//override
	public override void activate()
	{
		UnityEngine.MonoBehaviour.print("FAMILIAR");
		Object.Instantiate(activationPrefab);
	}
}
