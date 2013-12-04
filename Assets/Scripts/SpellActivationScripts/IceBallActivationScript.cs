using UnityEngine;
using System.Collections;

public class IceBallActivationScript : MonoBehaviour {
	
	GameObject chara;
	
	float speed;
	float projectileDuration;
	float slowDuration;
	Collider[] colliders;
	GameObject affectedEnemy;
	RaycastHit colCast;
	
	bool hit;
	
	// Use this for initialization
	void Start () {
		chara = GameObject.Find ("Character");
		transform.position = chara.transform.position;
		transform.localRotation = chara.transform.localRotation;
		
		speed = 4f;
		projectileDuration = 8f;
		slowDuration = 8f;
		hit = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!hit)
		{
			projectileDuration -= Time.deltaTime;
			if(projectileDuration <= 0f)
				Destroy (gameObject);
			if(Physics.SphereCast (transform.position,collider.bounds.size.x/2,transform.forward, out colCast,speed*Time.deltaTime))
				Destroy (gameObject);
			transform.Translate (0f,0f,speed*Time.deltaTime);
			colliders = Physics.OverlapSphere(transform.position,collider.bounds.size.x/2);
			foreach(Collider col in colliders)
			{
				if(col.CompareTag ("Enemy"))
				{
					hit = true;
					affectedEnemy = col.gameObject;
					print("Affected enemy is... " + affectedEnemy.name);
					(affectedEnemy.GetComponent(typeof(Stats)) as Stats).speed -= 70;
					(affectedEnemy.GetComponent(typeof(Stats)) as Stats).health -= 30;
					renderer.enabled = false;
					collider.enabled = false;
					
					break;
				}
			}
		}
		else
		{
			if(affectedEnemy == null)
				Destroy (gameObject);
			slowDuration -= Time.deltaTime;
			if(slowDuration <= 0f)
			{
				(affectedEnemy.GetComponent(typeof(Stats)) as Stats).speed += 70;
				Destroy(gameObject);
			}
			
		}
			
	}
}
