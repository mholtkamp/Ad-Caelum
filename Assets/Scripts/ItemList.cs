using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemList : MonoBehaviour {

	public List<Item> possibleItems;
	public List<Item> currentItems;
	public int selectedItem;
	public int red, blue, green, black;
	// Use this for initialization
	void Start () {
	  int selectedItem = 0;
	  possibleItems = new List<Item>();
	  possibleItems.Add(new Item("healthpotion"));
	  possibleItems.Add(new Item("goldherb"));
	  possibleItems.Add(new Item("healthpotion"));
	  possibleItems.Add(new Item("goldherb"));
	  possibleItems.Add(new Item("scrollred"));
	  possibleItems.Add(new Item("scrollgreen"));
	  possibleItems.Add(new Item("scrollblack"));
	  possibleItems.Add(new Item("scrollblue"));
		
	  currentItems = new List<Item>();
	  currentItems.Add(new Item("healthpotion"));
	  //possibleItems.Add(new Item("Health Potion"));
	  red = Random.Range(0,14);
	  green = Random.Range(0,14);
	  black = Random.Range(0,14);
	  blue = Random.Range(0,14);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	int getRed()
	{
		return red;	
	}
}
