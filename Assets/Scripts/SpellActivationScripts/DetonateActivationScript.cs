using UnityEngine;
using System.Collections;

public class DetonateActivationScript : MonoBehaviour {
	
	float hitTimer,hitTimerMax;
	float duration;
	float damage;
	Collider[] enemies;
	// Use this for initialization
	void Start () {
		hitTimerMax = 0.25f;
		hitTimer = hitTimerMax;
		duration = 10f;
		damage = 10f;
		
		Plane intersectionPlane = new Plane(Vector3.up, transform.position);
		float intersectDistance = 0.0f;

		Ray cursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(intersectionPlane.Raycast(cursorRay, out intersectDistance))
		{
			Vector3 pos = cursorRay.GetPoint(intersectDistance);
			pos.y = 0.01f;
			transform.position = pos;
		}
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		hitTimer -= Time.deltaTime;
		duration -= Time.deltaTime;
		if(hitTimer <= 0f)
		{
			enemies = Physics.OverlapSphere (transform.position,transform.localScale.x/2f);
			for(int i = 0; i < enemies.Length; i++)
			{
				if(enemies[i].CompareTag ("Enemy"))
					((Stats) (enemies[i].GetComponent (typeof(Stats)))).health -= damage;
			}
			
			hitTimer = hitTimerMax;
		}
		
		if(duration <= 0f)
			Destroy(transform.gameObject);
		
	}
}
