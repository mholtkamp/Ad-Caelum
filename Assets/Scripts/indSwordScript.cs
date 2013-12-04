using UnityEngine;
using System.Collections;

public class indSwordScript : MonoBehaviour {
	private RaycastHit colCast;
	private Collider[] colls;
	private Stats enemyStats;
	private GameObject enemy;
	public float damage, flySpeed;
	private bool found;
	// Use this for initialization
	void Start () {
		damage = 25f;
		found = false;
		flySpeed = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		colls = Physics.OverlapSphere (transform.position,collider.bounds.size.x/2);
		
		if(found == false)
		{
			foreach(Collider col in colls)
			{
				if(col.tag.Equals ("Enemy"))
				{
					found = true;
					enemy = col.gameObject;
					enemyStats = (Stats) enemy.GetComponent(typeof(Stats));

				}
				if(found == true)
					break;
			}
		}
		else
		{
			transform.parent = null;
			if(enemy == null)
			{
			  Destroy (gameObject);	
			}
			else
			{
					
				transform.LookAt(enemy.transform.position);
				transform.Rotate(-90f,0,0);
				transform.Translate(0f,-1*flySpeed*Time.deltaTime,0f);
				if((enemy.transform.position-transform.position).magnitude < 0.1f)
				{
					enemyStats.health -= damage;
					Destroy(gameObject);
				}
			}
		}
	}
}
