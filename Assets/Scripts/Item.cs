using UnityEngine;
using System.Collections;
using System;

public class Item {
	
	public String name;
	public Texture texture;
	GameObject activationPrefab;
	
	public Item()
	{
		
	}
	public Item(String givenName)
	{
		name = givenName;	
		texture = (Texture) Resources.Load (name+"texture");
		activationPrefab = (GameObject) Resources.Load (name+"prefab");
	}
	public void activate()
	{
		UnityEngine.MonoBehaviour.print(name);
		UnityEngine.Object.Instantiate(activationPrefab);
	}
	
}