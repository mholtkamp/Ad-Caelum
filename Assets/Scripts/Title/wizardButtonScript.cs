using UnityEngine;
using System.Collections;

public class wizardButtonScript : MonoBehaviour {
	public float x,y,width,height;
	bool visible;
	public bool faded;
	classTextScript cts;
	selectedClassScript css;
	// Use this for initialization
	void Start () {
		cts = (classTextScript) GameObject.Find ("ClassText").GetComponent(typeof(classTextScript));
		css = (selectedClassScript) GameObject.Find ("selectedClass").GetComponent(typeof(selectedClassScript));
		visible = false;
		faded = false;
		Color newColor = guiTexture.color;
		newColor.a = 0f;
		guiTexture.color = newColor;
		x = -0.23f;
		y = -0.39f;
		width = 0.07f;
		height = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
		guiTexture.pixelInset = new Rect(Screen.width*x,Screen.height*y,Screen.width*width,Screen.height*height);

		if(cts.classSelected)
		{
			visible = false;
			StartCoroutine("fade");
		}

	}
	
	public void show()
	{
		if(!visible)
		{
			visible = true;
			StartCoroutine ("fadein");
		}
	}
	
	IEnumerator fadein()
	{
		for (float f = 0f; f <= 0.5; f += 0.03f) 
		{
			Color c = guiTexture.color;
			c.a = f;
			guiTexture.color = c;
			yield return 0;
		}
		
		Color c2 = guiTexture.color;
		c2.a = 0.5f;
		guiTexture.color = c2;
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
		faded = true;
	}
	
	void OnMouseUp()
	{
		if(visible)
		{
			cts.classSelected = true;
			css.selectedClass = 2;	
		}
	}
}
