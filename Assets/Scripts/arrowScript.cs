using UnityEngine;
using System.Collections;

public class arrowScript : MonoBehaviour {
	
	float timer;
	GameObject chara;
	public float speed;
	private Stats charaStats, enemyStats, chestStats;
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
		//transform.Translate(0f,0.5f,0f);
		speed = 4f;
		damage = 25f*charaStats.damage/3f;
		didDamage = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		if(timer < 0)
		{
			didDamage = true;
		}
		x = transform.position.x;
		y = chara.transform.position.y;
		z = transform.position.z;
		shootingPosition = new Vector3(x,y,z);
		if(Physics.Raycast(shootingPosition,transform.forward,out colCast, 2.25f*speed*Time.deltaTime))
	  	{
				if(colCast.collider.tag.Equals ("Wall") && (didDamage == false))
				{
					didDamage = true;	
				}
				if(colCast.collider.tag.Equals("Enemy") && (didDamage == false))
				{
					enemyStats = (Stats) colCast.collider.gameObject.GetComponent(typeof(Stats));
					//	print ("HIT THE ENEMY!");
					enemyStats.health -= damage;
					didDamage = true;	
				}
				if(colCast.collider.tag.Equals("Chest")&& (didDamage == false))
				{
					chestStats = (Stats) colCast.collider.gameObject.GetComponent(typeof(Stats));
					//	print ("HIT THE ENEMY!");
					chestStats.health -= 101f;
					didDamage = true;	
				}
			
		}
		transform.Translate(0f,0f,speed*Time.deltaTime);
		if(didDamage)
			Destroy(gameObject);
		
	}
}
