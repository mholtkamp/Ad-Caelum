using UnityEngine;
using System.Collections;

public class diffButtonScript : MonoBehaviour {
	bool visible;
	public bool faded;
	static bool diffSelected;
	public float x,y,width,height;
	selectedClassScript css;
	// Use this for initialization
	void Start () {
		css = (selectedClassScript) GameObject.Find ("selectedClass").GetComponent(typeof(selectedClassScript));
		visible = false;
		diffSelected = false;
		faded = false;
		Color newColor = guiTexture.color;
		newColor.a = 0f;
		guiTexture.color = newColor;
		x = -0.40f;
		y = 0.1f;
		width = 0.05f;
		height = 0.1f;
		if(gameObject.name == "difficulty2")
		{
			width = 0.1f;
			y = -0.05f;
		}
		else if(gameObject.name == "difficulty3")
		{
			width = 0.15f;
			y = -0.2f;
		}
			
		
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
		guiTexture.pixelInset = new Rect(Screen.width*x,Screen.height*y,Screen.width*width,Screen.height*height);
		if(diffSelected)
		{
			visible = false;
			StartCoroutine("fade");
		}
	}
	
	public void show()
	{
		if(!visible)
		{
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
		visible = true;
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
			diffSelected = true;
			if(gameObject.name.Equals("difficulty1"))
				css.difficulty = 1;
			if(gameObject.name.Equals("difficulty2"))
				css.difficulty = 2;
			if(gameObject.name.Equals("difficulty3"))
				css.difficulty = 3;	
				
		}
	}
}
