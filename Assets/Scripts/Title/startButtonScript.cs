
using UnityEngine;
using System.Collections;

public class startButtonScript : MonoBehaviour {
	public float x,y,width,height;
	public bool started;
	public bool faded;

	void Start()
	{
		started = false;
		transform.position = Vector3.zero;
		transform.localScale = Vector3.zero;
		x = 0.6f;
		y = 0.3f;
		width = 0.4f;
		height = 0.12f;
		
	}
	
	void Update() {

		guiTexture.pixelInset = new Rect(Screen.width*x,Screen.height*y,Screen.width*width,Screen.height*height);
		if(guiTexture.color.a == 0f)
			faded = true;
	}
	
	// Update is called once per frame
	void OnMouseUp() {
		started = true;
		StartCoroutine ("fade");
		
		//Application.LoadLevel("lvl1");
	}
	
	IEnumerator fade()
	{
		for (float f = 0.5f; f >= 0; f -= 0.03f) 
		{
			Color c = guiTexture.color;
			c.a = f;
			guiTexture.color = c;
			yield return 0;
		}
		
		Color c2 = guiTexture.color;
		c2.a = 0f;
		guiTexture.color = c2;
	}

}
