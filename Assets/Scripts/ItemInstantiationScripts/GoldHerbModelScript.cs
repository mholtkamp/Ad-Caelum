using UnityEngine;
using System.Collections;

public class GoldHerbModelScript : MonoBehaviour {
	public GameObject character;
	private float x,y,z;
	private Vector3 itemPosition;
	private Collider[] colliderArray;
	public ItemList characterItems;
	// Use this for initialization
	void Start () {
		character = GameObject.Find("Character");
		characterItems = (ItemList) character.GetComponent(typeof (ItemList));
		x = transform.position.x;
		y = character.transform.position.y;
		z = transform.position.z;
		itemPosition = new Vector3(x,y,z);
		transform.Rotate(0,270f,270f);

	}
	
	// Update is called once per frame
	void Update () {
		colliderArray = Physics.OverlapSphere(itemPosition,collider.bounds.size.x/2); 
	  	foreach(Collider col in colliderArray)
		{
			if(col.gameObject.Equals(character))
			{
			  characterItems.currentItems.Add(new Item("goldherb"));
			  Destroy(gameObject);
			}
		}
	}
}
