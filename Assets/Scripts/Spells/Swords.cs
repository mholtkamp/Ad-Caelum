using UnityEngine;
using System.Collections;

public class Swords : Spell {

	public Swords()
	{
		texture = (Texture) Resources.Load ("Swords");
		activationPrefab = (GameObject) Resources.Load ("SwordsActivationPrefab");
	}
	
	//override
	public override void activate()
	{
		UnityEngine.MonoBehaviour.print("SWORDS");
		Object.Instantiate(activationPrefab);
	}
}
