using UnityEngine;
using System.Collections;

public class Barrier : Spell {
	
	public Barrier()
	{
		texture = (Texture) Resources.Load ("Barrier");
		activationPrefab = (GameObject) Resources.Load ("BarrierActivationPrefab");
	}
	
	//override
	public override void activate()
	{
		UnityEngine.MonoBehaviour.print("BARRIER");
		Object.Instantiate(activationPrefab);
	}
}
