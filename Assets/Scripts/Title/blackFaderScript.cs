using UnityEngine;
using System.Collections;

public class blackFaderScript : MonoBehaviour {
	
	float fadeTime;
	float timer;
	public bool faded;
	public float x,y,width,height;

	// Use this for initialization
	void Start () {
		fadeTime = 1.5f;
		timer = 0f;
		faded = false;
		x = -0.5f;
		y = -0.5f;
		width = 1.5f;
		height = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		guiTexture.pixelInset = new Rect(Screen.width*x,Screen.height*y,Screen.width*width,Screen.height*height);
		timer += Time.deltaTime;
		Color newColor = guiTexture.color;
		newColor.a = (timer/fadeTime)*0.5f;
		guiTexture.color = newColor;
		
		if(timer > fadeTime)
			faded = true;
	}
}
