using UnityEngine;
using System.Collections;

public class scrollGreenActivationScript : MonoBehaviour {
	private GameObject character;
	private ItemList charsItems;
	private int currentEffect;
	private Stats charsStats;
	public GameObject dungeon;
	public DunGen dungen;
	private int xPos;
	private int yPos;

	// Use this for initialization
	void Start () {
	  character = GameObject.Find("Character");
	  charsItems = (ItemList) character.GetComponent(typeof (ItemList)); 
	  currentEffect = charsItems.green;
	  charsStats = (Stats) character.GetComponent(typeof (Stats));
		print ("EFFECT NUMBER: " + currentEffect);
		
		if(currentEffect == 0 && currentEffect == 1)
		{
			charsStats.maxHealth += 25f;
			charsStats.health += 25f;
		}
		if(currentEffect == 2 || currentEffect == 3)
		{
			charsStats.damage += 1;
		}
		if(currentEffect == 4 || currentEffect == 5)
		{
			charsStats.speed += 25;
		}
		if(currentEffect == 6 || currentEffect == 7)
		{
			charsStats.wisdom += 1;
		}
		if(currentEffect == 8)
		{
			charsStats.maxHealth -= 25f;
			if(charsStats.health - 25f <= 0f)
			{
			  charsStats.health = 1f;	
			}
			else
			{
			  charsStats.health -= 25f;
			}
		}
		if(currentEffect == 9)
		{
			charsStats.damage -= 1;
			if(charsStats.damage <= 0)
				charsStats.damage = 1;
		}
		if(currentEffect == 10)
		{
			charsStats.speed -= 25;
			if (charsStats.speed <= 50)
			{
				charsStats.speed = 50;	
			}
		}
		if(currentEffect == 11)
		{
			charsStats.wisdom -= 1;
			if(charsStats.wisdom <= 0)
				charsStats.wisdom = 1;
		}
		if(currentEffect == 12)
		{
			charsStats.health = 1f;
		}
		if(currentEffect == 13)
		{
			teleport();
		}
		
		
	  GameObject.Destroy(gameObject);
	}
	
	private void teleport()
	{
			dungeon = GameObject.Find("DungeonGenerator");
		    dungen = (DunGen) dungeon.GetComponent(typeof (DunGen));
			bool posFound = false;
			//int[,] map = new int[30,30];// dungen.getTiles();// new int[30,30];
		    //map[0,0] = dungen.map[0,0];
		//dungen.
		//dungen.map
		//dungen
			while(!posFound)
			{
				xPos =	Random.Range (0,30/*dungen.MAP_WIDTH*/);
				yPos =  Random.Range (0,30/*dungen.MAP_HEIGHT*/);

				//map = dungen.map;
			
				if(dungen.map[xPos,yPos] == 1)
				{
					posFound = true;
				    float y = character.transform.position.y;
					character.transform.position = new Vector3(xPos,y,yPos);
				}
				
			}
		
	}
	
}