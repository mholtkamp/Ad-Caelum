using UnityEngine;
using System.Collections;

public class spellBarScript : MonoBehaviour {


	public float x,y,width,height;
	GUITexture[] spellTextures;
	private SpellBar bar;
	Vector4 opaque;
	Vector4 translucent;
	Vector4 invisible;
	
	void Start()
	{
		opaque = new Vector4(0.5f,0.5f,0.5f,1f);
		translucent = new Vector4(0.5f,0.5f,0.5f,0.212f);
		invisible = new Vector4(0.5f,0.5f,0.5f,0f);
		spellTextures = new GUITexture[3];
		spellTextures[0] = (GUITexture)  GameObject.Find("Spell1").GetComponent (typeof(GUITexture));
		spellTextures[1] = (GUITexture)  GameObject.Find("Spell2").GetComponent (typeof(GUITexture));
		spellTextures[2] = (GUITexture)  GameObject.Find("Spell3").GetComponent (typeof(GUITexture));

		bar = new SpellBar();
		refreshSpellTextures();
	
		
		
		for(int i = 0; i < 3; i++)
			{
				if(i == bar.selectedSpell)
					spellTextures[i].color = opaque;
				else
					spellTextures[i].color = translucent;
			}
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.CapsLock))
		{
			bar.cycleSelectedSpell();
			for(int i = 0; i < 3; i++)
			{
				if(spellTextures[i].texture != null)
				{
					if(i == bar.selectedSpell)
						spellTextures[i].color = opaque;
					else
						spellTextures[i].color = translucent;
				}
			}
		}
		
		if(Input.GetMouseButtonDown(1))
		{
			spellTextures[bar.selectedSpell].texture = null;
			bar.activate();
			for(int i = 0; i < 3; i++)
			{
				if(spellTextures[i].texture != null)
				{
					if(i == bar.selectedSpell)
						spellTextures[i].color = opaque;
					else
						spellTextures[i].color = translucent;
				}
			}
		}
	}
	
	public void refreshSpellTextures()
	{
		for(int i = 0; i < 3; i++)
		{
			spellTextures[i].guiTexture.texture = bar.currentSpells[i].getTexture();
		}
		for(int i = 0; i < 3; i++)
		{
			if(spellTextures[i].texture != null)
			{
				if(i == bar.selectedSpell)
					spellTextures[i].color = opaque;
				else
					spellTextures[i].color = translucent;
			}
		}
	}
	
	public void drawSpells()
	{
		bar.selectedSpell = 0;
		bar.drawSpells();	
	}


}
