using UnityEngine;
using System.Collections;

public class spellPosScript : MonoBehaviour {
	
	public float x,y,width,height;
	Rect inset;
	// Use this for initialization
	void Start () {
		transform.position = Vector3.zero;
		transform.localScale = Vector3.zero;
		if(name.Equals ("Spell1"))
		{
			x = 0.018f;
			y = 0.83f;
			width = 0.07f;
			height = 0.14f;
		}
		else if(name.Equals ("Spell2"))
		{
			x = 0.095f;
			y = 0.83f;
			width = 0.07f;
			height = 0.14f;	
		}
		else if(name.Equals ("Spell3"))
		{
			x = 0.172f;
			y = 0.83f;
			width = 0.07f;
			height = 0.14f;	
		}
		inset = new Rect(Screen.width*x,Screen.height*y,Screen.width*width,Screen.height*height);
		guiTexture.pixelInset = inset;
	}
	
	void Update()
	{
		guiTexture.pixelInset = new Rect(Screen.width*x,Screen.height*y,Screen.width*width,Screen.height*height);

	}
	

}
