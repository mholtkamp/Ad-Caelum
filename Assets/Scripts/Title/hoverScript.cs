using UnityEngine;
using System.Collections;

public class hoverScript : MonoBehaviour {
	
	float tfR,tfG,tfB;
	const float selR = 0f;
	const float selG = 0.78f;
	const float selB = 0.90f;
	
	float oriR;
	float oriG;
	float oriB;
	float shiftSpeed;
	
	bool isHovering;
	
	// Use this for initialization
	void Start () {
	
		shiftSpeed = 2f;
		isHovering = false;
		
		oriR = guiTexture.color.r;
		oriG = guiTexture.color.g;
		oriB = guiTexture.color.b;
		
		tfR = (selR - oriR)*shiftSpeed;
		tfG = (selG - oriG)*shiftSpeed;
		tfB = (selB - oriB)*shiftSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		Color newColor = guiTexture.color;
		if(isHovering)
		{
			newColor.r += tfR * Time.deltaTime;
			newColor.g += tfG * Time.deltaTime;
			newColor.b += tfB * Time.deltaTime;
			
			if(newColor.r < selR)
				newColor.r = selR;
			if(newColor.g > selG)
				newColor.g = selG;
			if(newColor.b > selB)
				newColor.b = selB;
			
			
			
		}
		else
		{			
			newColor.r -= tfR * Time.deltaTime;
			newColor.g -= tfG * Time.deltaTime;
			newColor.b -= tfB * Time.deltaTime;
			
			
			if(newColor.r > oriR)
				newColor.r = oriR;
			if(newColor.g < oriG)
				newColor.g = oriG;
			if(newColor.b < oriB)
				newColor.b = oriB;
			
		}
		
		//print("R: " + newColor.r + "   G: " + newColor.g + "    B: " + newColor.b);
		guiTexture.color = newColor;
	}
	
	void OnMouseEnter()
	{
		isHovering = true;
	}
	
	void OnMouseExit()
	{
		isHovering = false;	
	}
}
