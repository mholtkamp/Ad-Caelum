using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class itemWheel : MonoBehaviour {
	public float startX, startY, widthX, heightY;
	private GUITexture itemGUI;
	private Texture healthpotiontexture;
	public ItemList charsItems;
	private GameObject chara;

	// Use this for initialization
	void Start () {
		chara = GameObject.Find("Character");
		startX = 0.81f;
		startY = 0f;
		widthX = 0.15f;
		heightY= 0.37f;
		transform.position = Vector3.zero;
        transform.localScale = Vector3.zero;
		itemGUI = (GUITexture) GetComponent(typeof(GUITexture));
		//healthpotiontexture = (Texture) Resources.Load("healthpotiontexture");
		charsItems = (ItemList) chara.GetComponent(typeof (ItemList));
		charsItems.selectedItem = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			if(charsItems.currentItems.Count > 1)
			{
		  	  charsItems.selectedItem +=1;
			  if(charsItems.selectedItem+1 > charsItems.currentItems.Count)
			  {
				charsItems.selectedItem = 0;
			  }
			}
		}
		else if(Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			if(charsItems.currentItems.Count > 1)
			{
		  	  charsItems.selectedItem -=1;
			  if(charsItems.selectedItem < 0)
			  {
				charsItems.selectedItem = charsItems.currentItems.Count-1;
			  }
			}
		}
		
		
		  if(charsItems.currentItems.Count == 0)
		  {
			itemGUI.texture = (Texture) Resources.Load("whiteborder");
		  }
		  else
		  {
			itemGUI.texture = charsItems.currentItems[charsItems.selectedItem].texture;
		  }
		if (Input.GetMouseButtonDown(2) && charsItems.currentItems.Count > 0)
		{
		  charsItems.currentItems[charsItems.selectedItem].activate();
	      charsItems.currentItems.RemoveAt(charsItems.selectedItem);
		  if(charsItems.selectedItem+1 > charsItems.currentItems.Count)
		  {
				charsItems.selectedItem -= 1;
				if(charsItems.selectedItem < 0)
					charsItems.selectedItem = 0;
		  }
		  if(charsItems.currentItems.Count == 0)
		  {
			itemGUI.texture = (Texture) Resources.Load("whiteborder");
		  }
		  else
		  {
			//print(charsItems.selectedItem);
			itemGUI.texture = charsItems.currentItems[charsItems.selectedItem].texture;
		  }
		  
		}
		guiTexture.pixelInset = new Rect(Screen.width*startX,Screen.height*startY, Screen.width*widthX, Screen.height*heightY);
	}
}
