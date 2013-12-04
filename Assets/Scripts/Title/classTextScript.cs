using UnityEngine;
using System.Collections;

public class classTextScript : MonoBehaviour {
	public float x,y;
	bool visible;
	public bool classSelected;
	public bool faded;
	// Use this for initialization
	void Start () {
		classSelected = false;
		visible = false;
		Color newColor = guiText.color;
		newColor.a = 0f;
		guiText.color = newColor;
		x = -0.44f;
		y = 0.09f;
		guiText.pixelOffset = new Vector2(Screen.width*x,Screen.height*y);
	}
	
	// Update is called once per frame
	void Update () {
		guiText.pixelOffset = new Vector2(Screen.width*x,Screen.height*y);
		if(classSelected)
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
			StartCoroutine("fadein");		
		}
	}
	
	IEnumerator fadein()
	{
		for (float f = 0f; f <= 1f; f += 0.06f) 
		{
			Color c = guiText.color;
			c.a = f;
			guiText.color = c;
			yield return 0;
		}
		
		Color c2 = guiText.color;
		c2.a = 1f;
		guiText.color = c2;
	}
	
	IEnumerator fade()
	{
		for (float f = 1f; f >= 0; f -= 0.06f) 
		{
			Color c = guiText.color;
			c.a = f;
			guiText.color = c;
			yield return 0;
		}
		
		Color c2 = guiText.color;
		c2.a = 0f;
		guiText.color = c2;
		faded = true;
	}
}
