using UnityEngine;
using System.Collections;

public class FireBall : Spell{

	// Use this for initialization
	public FireBall()
	{
		texture = (Texture) Resources.Load ("FireBallSplash");
		activationPrefab = (GameObject) Resources.Load ("FireBallParent");
	}
	
	public override void activate ()
	{
		UnityEngine.MonoBehaviour.print("FireBall!!");
		Object.Instantiate(activationPrefab);
	}
	
}
