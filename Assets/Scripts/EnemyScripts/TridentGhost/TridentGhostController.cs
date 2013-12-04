using UnityEngine;
using System.Collections;

public class TridentGhostController : MonoBehaviour {
	Stats stats;
	GameObject chara;
	Stats charaStats;
	Vector3 displacement;
	bool isAttacking;
	float attackDistance;
	float hitCheckTimer;
	RaycastHit colCast;
	BasicMovementScript bms;
	
	// Use this for initialization
	void Start () {
		chara = GameObject.Find ("Character");
		charaStats = (Stats) chara.GetComponent (typeof(Stats));
		stats = (Stats) GetComponent(typeof(Stats));
		setBaseStats();
		displacement = new Vector3();
		isAttacking = false;
		attackDistance = 0.5f;
		bms = (BasicMovementScript) GetComponent (typeof(BasicMovementScript));

	}
	
	// Update is called once per frame
	void Update () {
		
		displacement.x = chara.transform.position.x - transform.position.x;
		displacement.z = chara.transform.position.z - transform.position.z;
		
		if((displacement.magnitude < attackDistance) || isAttacking)
		{
			if(!isAttacking)
			{
				hitCheckTimer = 0.3f;
				isAttacking = true;
				animation.Play ("Attack");
				bms.disable ();
			}
			
			hitCheckTimer -= Time.deltaTime;
			
			if(hitCheckTimer <= 0f)
			{
				if(Physics.Raycast (transform.position, displacement, out colCast, attackDistance + 0.2f))
				{
					if(colCast.transform.gameObject == chara)
					{
						charaStats.health -= stats.damage;
						hitCheckTimer = 99999f;
					}
				}
				
			}
			
			if(!animation.IsPlaying("Attack"))
			{
				isAttacking = false;
			}
			
		}
		else
			bms.enable ();
		
		if(stats.health <= 0)
			Destroy (gameObject);
	}
	
	
	private void setBaseStats()
	{
		stats.speed = 200;
		stats.damage = 15;
		stats.attackSpeed = 0;
		stats.wisdom = 0;
		stats.health = 100;
		stats.maxHealth = stats.health;
	}
}
