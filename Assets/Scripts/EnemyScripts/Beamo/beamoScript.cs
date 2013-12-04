using UnityEngine;
using System.Collections;

public class beamoScript : MonoBehaviour {
	private GameObject character;
	private Stats characterStats;
	private Stats stats;
	private bool found;
	public float distanceOfSight, rotateSpeed;
	private RaycastHit colCast;
	public Vector3 shootingDirection;
	private float x, y, z, timeForShoot,maxTimeForShoot;
	// Use this for initialization
	void Start () {
		character = GameObject.Find("Character");
		characterStats = (Stats) character.GetComponent(typeof (Stats));
		stats = (Stats) GetComponent (typeof(Stats));
		distanceOfSight = 3f;
		rotateSpeed = 110f;
		shootingDirection = new Vector3(0f,0f,0f);
		timeForShoot = 0f;
		maxTimeForShoot = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(stats.health <= 0f)
			Destroy (gameObject);
		//print (transform.forward);

		//print (transform.position - character.transform.position);
		if(!found)
		{
		x = transform.position.x;
		y = character.transform.position.y;
		z = transform.position.z;
		shootingDirection = new Vector3(x,y,z);
			transform.Rotate(0f,rotateSpeed*Time.deltaTime,0f);
			if(Physics.Raycast(shootingDirection,transform.forward,out colCast, distanceOfSight))
	  		{
			  if(colCast.collider.gameObject.Equals(character))
			  {
			    found = true;
			  }
			}
		}
		else
		{
			timeForShoot += Time.deltaTime;
			transform.LookAt(character.transform.position);
			transform.localEulerAngles = new Vector3(0,transform.rotation.eulerAngles.y,0);
			if((transform.position - character.transform.position).magnitude >= distanceOfSight)
			{
				found = false;
				timeForShoot = 0f;
			}
			if(timeForShoot >= maxTimeForShoot)
			{
				Instantiate((GameObject) Resources.Load("spikeball"), transform.position, transform.localRotation).name = "spikeball";
				//GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        		//sphere.transform.position = transform.position;
				timeForShoot = 0f;
			}
			
			//shoot a ball
			//instantiate a glowing thing maybe and shoot it?
		}
	
	}

}
