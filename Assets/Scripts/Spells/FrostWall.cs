using UnityEngine;
using System.Collections;

public class FrostWall : Spell{

	// Use this for initialization
	public FrostWall()
	{
		texture = (Texture) Resources.Load ("FrostWall");
		activationPrefab = (GameObject) Resources.Load ("IceWallParent");
	}
	
	public override void activate ()
	{
		UnityEngine.MonoBehaviour.print("FROSTWALL!");
		Object.Instantiate(activationPrefab);
	}
	
}
