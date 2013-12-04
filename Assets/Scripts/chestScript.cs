using UnityEngine;
using System.Collections;

public class chestScript : MonoBehaviour {
	private Stats chestStats;
	private Item itemDrop;
	private ItemList possibleItemsHolder; 
	private GameObject chara;
	
	// Use this for initialization
	void Start () {
		chara = GameObject.Find("Character");
		chestStats = (Stats) GetComponent(typeof (Stats));
	}
	
	// Update is called once per frame
	void Update () {
		if(chestStats.health <= 0)
		{
			//replace with another object
			possibleItemsHolder = (ItemList) chara.GetComponent(typeof (ItemList));
			itemDrop = (Item) possibleItemsHolder.possibleItems[Random.Range(0,possibleItemsHolder.possibleItems.Count)];
			Instantiate((GameObject) Resources.Load(itemDrop.name+"model"), transform.position, transform.localRotation).name = itemDrop.name;
			Destroy(gameObject);	
		}
	}
}
