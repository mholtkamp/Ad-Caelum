using UnityEngine;
using System.Collections;

public class spikeballScript : MonoBehaviour {
	
	float timer;
	GameObject chara;
	public float speed;
	private Stats charaStats;
	private RaycastHit colCast;
	public float damage,x,y,z;
	private bool didDamage;
	private Vector3 shootingPosition;
	// Use this for initialization
	void Start () 
	{
		timer = 1f;
		chara = GameObject.Find("Character");
		charaStats = (Stats) chara.GetComponent(typeof(Stats));		
		transform.Translate(0f,0.5f,0f);
		speed = 6f;
		damage = 8f;
		didDamage = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		if(timer < 0)
		{
			Destroy(gameObject);
		}
		x = transform.position.x;
		y = chara.transform.position.y;
		z = transform.position.z;
		shootingPosition = new Vector3(x,y,z);
		if(Physics.Raycast(shootingPosition,transform.forward,out colCast, 1.75f*speed*Time.deltaTime))
	  	{
		  if(colCast.collider.tag.Equals ("Wall"))
		  {
			Destroy(gameObject);	
		  }
		  if(colCast.collider.gameObject.Equals(chara))
		  {
			if(!didDamage)
			{
		      charaStats.health -= damage;
			  didDamage = true;	
			}
		  }
			
		}
		transform.Translate(0f,0f,speed*Time.deltaTime);
		
	}
}
