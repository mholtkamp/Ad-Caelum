using UnityEngine;
using System.Collections;

public abstract class Spell{
	
	protected Texture texture;
	protected GameObject activationPrefab;
	
	public Spell()
	{
		
	}
	
	abstract public void activate();

	
	public Texture getTexture()
	{
		return texture;	
	}
}
