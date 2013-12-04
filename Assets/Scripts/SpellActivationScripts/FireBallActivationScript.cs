using UnityEngine;
using System.Collections;

public class FireBallActivationScript : MonoBehaviour {
	
	float timer;
	GameObject chara;
	public float speed;
	Vector3 fireBallForward;
	Vector3 realForward;
	private Stats enemyStats;
	private RaycastHit colCast;
	public float damage;
	private Collider[] colls;
	// Use this for initialization
	void Start () {
		
		timer = 4f;
		chara = GameObject.Find("Character");
		transform.position = chara.transform.position;
		transform.Translate(chara.transform.forward*.5f);
		//transform.Translate(0f,1.820859f,0f);
		transform.forward = chara.transform.forward;
		speed = 2f;
		transform.Translate(-0.08f,0f,0f);
		realForward = new Vector3(0f,0f,1f);
		damage = 80f;
	}
	
	// Update is called once per frame
	void Update () {
		
		/*
		 if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,transform.forward,out colCast,speed*Time.deltaTime))
		  {
			if(colCast.collider.tag.Equals("Enemy"))
			{
				enemyStats = (Stats) colCast.collider.gameObject.GetComponent(typeof(Stats));
				//	print ("HIT THE ENEMY!");
				enemyStats.health -= damage*Time.deltaTime;
				//noDamageYet = false;	
			}
		  }
		 */
		colls = Physics.OverlapSphere (transform.position,collider.bounds.size.x/2);
		
		foreach(Collider col in colls)
		{
			if(col.tag.Equals ("Enemy"))
			{
				enemyStats = (Stats) col.gameObject.GetComponent(typeof(Stats));
				enemyStats.health -= damage*Time.deltaTime;	
			}
		}
		
		transform.Translate(0f,0f,speed*Time.deltaTime);
		timer -= Time.deltaTime;
		if(timer < 0)
		{
			GameObject.Destroy (transform.FindChild ("fireBall").gameObject);
			GameObject.Destroy (transform.FindChild ("ParticleSystem").gameObject);
			Destroy(gameObject);
		}
	}
}
