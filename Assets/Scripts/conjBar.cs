using UnityEngine;
using System.Collections;

public class conjBar : MonoBehaviour {
	
	public float startX, startY, widthX, heightY, growthRate;
	private float maxWidth;
	private GUITexture conjureBar;
	private Texture bright, dim;
	public float timeCounter, maxTime;
	private bool dark;
	private spellBarScript sbs;
	Stats charStats;
	
	// Use this for initialization
	void Start () {
		charStats = (Stats) GameObject.Find ("Character").GetComponent(typeof(Stats));
	    startX = 0.285f;
		startY = 0.91f;
		widthX = 0f;
		heightY= 0.06f;
		//guiTexture.pixelInset.height = 0.15f*Screen.height;
		transform.position = Vector3.zero;
        transform.localScale = Vector3.zero;
		maxWidth = 0.43f;
		growthRate = 0.04f;
	    conjureBar = (GUITexture) GetComponent(typeof(GUITexture));
		bright = (Texture) Resources.Load("ConjBar1");
		dim = (Texture) Resources.Load("ConjBar2");
		maxTime = 0.4f;
		timeCounter = maxTime;
		sbs = (spellBarScript) GameObject.Find("SpellBarHUD").GetComponent (typeof(spellBarScript));
	}
	
	// Update is called once per frame
	void Update () {
	
	  growthRate = charStats.wisdom*(0.04f/3f);
	  if(widthX < maxWidth)
	  {
	    widthX += Time.deltaTime*growthRate;
	  }
	  else
	  {
	    widthX = maxWidth;		
	  }
	  guiTexture.pixelInset = new Rect(Screen.width*startX,Screen.height*startY, Screen.width*widthX, Screen.height*heightY);
	  if(widthX == maxWidth)
	  {
		if(timeCounter < maxTime)
		{
		  timeCounter += Time.deltaTime; 
		}
		else
		{
		  timeCounter = 0;
		  if(dark)
		  {
			conjureBar.texture = bright;			
		  }
		  else
		  {
			conjureBar.texture = dim;
		  }
		  dark = !dark;
		}
	  
	    if(Input.GetKeyDown(KeyCode.Space))
		{
		  conjure(); 
		}
	  }
	}
	
	void conjure()
	{
	  //find 3 spells from spell pool array
	  widthX = 0f;
	  sbs.drawSpells ();
	  sbs.refreshSpellTextures();
	  
	}
	

}
