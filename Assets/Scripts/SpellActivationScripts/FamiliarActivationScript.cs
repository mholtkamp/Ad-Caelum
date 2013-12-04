using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FamiliarActivationScript : MonoBehaviour {
	
	float duration;
	public enum Direction {Up,Down,Left,Right};
	public Direction dir;
	public float dirTimer;
	const float dirChangeTime = 1f;
	const float targetCheckDist = 2f;
	const float collisionBuffer = 0.001f;
	bool targetFound;
	RaycastHit colCast;
	float speed;
	Vector3 upRot,rightRot,downRot,leftRot;
	float attackTimer;
	const float attackTimerMax = 2f;
	float tickTimer;
	const float tickTimerMax = 0.15f;
	Vector3 castPos;
	Vector3 castDir;
	List<GameObject> enemies;
	GameObject chara;
	
	public GameObject[] checkSpheres;
	List<GameObject> hits;
	
	// Use this for initialization
	void Start ()
	{
		chara = GameObject.Find ("Character");
		Vector3 pos = chara.transform.position;
		pos.y = 0.1176f;
		transform.position = pos;
		duration = 15f;
		dir = (Direction) Random.Range ((int)Direction.Up,(int)Direction.Right+1);
		targetFound = false;
		speed = 1.5f;
		upRot = new Vector3(0,0,0);
		rightRot = new Vector3(0,90f,0);
		downRot = new Vector3(0,180f,0);
		leftRot = new Vector3(0,270f,0);
		animation.wrapMode = WrapMode.Loop;
		animation.Play ("Move");
		attackTimer = attackTimerMax;
		tickTimer = tickTimerMax;
		enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
		particleSystem.Stop();
		checkSpheres = new GameObject[4];
		checkSpheres[0] = transform.FindChild("famfirechecksphere1").gameObject;
		checkSpheres[1] = transform.FindChild("famfirechecksphere2").gameObject;
		checkSpheres[2] = transform.FindChild("famfirechecksphere3").gameObject;
		checkSpheres[3] = transform.FindChild("famfirechecksphere4").gameObject;
		disableCheckSphereColliders();
		hits = new List<GameObject>();

		
		
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		duration -= Time.deltaTime;
		if(duration <= 0f)
			Destroy(gameObject);
		if(!targetFound)
		{
			dirTimer -= Time.deltaTime;
			if(dirTimer <= 0f)
			{
				dir = (Direction) Random.Range ((int)Direction.Up,(int)Direction.Right+1);
				dirTimer = dirChangeTime;
			}
			castPos = transform.position;
			castPos.y = 0.3f;
			foreach(GameObject en in enemies)
			{
				try
				{
					
					castDir = en.transform.position - castPos;
					Debug.DrawRay(castPos,castDir);
					if(Physics.Raycast (castPos,castDir,out colCast,targetCheckDist))
					{
						if(colCast.collider.gameObject.CompareTag("Enemy"))
						{
							targetFound = true;	
							tickTimer = tickTimerMax;
							attackTimer = attackTimerMax;
							transform.LookAt(en.transform);
							Vector3 lookRot = transform.localEulerAngles;
							lookRot.x = 0;
							lookRot.z = 0;
							transform.localEulerAngles = lookRot;
							particleSystem.Play();
							enableCheckSphereColliders();
							return;
						}
					}
				}
				catch(MissingReferenceException ex)
				{
					enemies.Remove (en);
					break;
				}

			}
			
			

			if(dir == Direction.Up)//move up
			{
				transform.localEulerAngles = upRot;
				if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.forward,out colCast,speed*Time.deltaTime))
				{
				  transform.Translate (0f,0f,colCast.distance - collisionBuffer,Space.World);
				  while(dir == Direction.Up)
				  {
				    dir = (Direction) Random.Range(0,4);	
				  }
				  dirTimer = dirChangeTime;
				}
				else
				{
				  transform.Translate(0f,0f,speed*Time.deltaTime,Space.World);
				}
			}
			else if(dir == Direction.Right)//move right
			{
				transform.localEulerAngles = rightRot;
				if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.right,out colCast,speed*Time.deltaTime))
				{
				  transform.Translate (colCast.distance - collisionBuffer,0f,0f,Space.World);
				  while(dir == Direction.Right)
				  {
				    dir = (Direction) Random.Range(0,4);	
				  }
				  dirTimer = dirChangeTime;
				}
				else
				{
				  transform.Translate(speed*Time.deltaTime,0f,0f,Space.World);
				}  				
			}
			else if(dir == Direction.Down)//move down
			{
				transform.localEulerAngles = downRot;
				if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.back,out colCast,speed*Time.deltaTime))
				{
				  transform.Translate (0f,0f,-colCast.distance + collisionBuffer,Space.World);
				  while(dir == Direction.Down)
				  {
				    dir = (Direction)Random.Range(0,4);	
				  }
				  dirTimer = dirChangeTime;
				}
				else
				{
				  transform.Translate(0f,0f,-speed*Time.deltaTime,Space.World);
				}  	
				
			}
			else//move left
			{
				transform.localEulerAngles = leftRot;
				if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.left,out colCast,speed*Time.deltaTime))
				{
				  transform.Translate (-colCast.distance + collisionBuffer,0f,0f,Space.World);
				  while(dir == Direction.Left)
				  {
				  		dir = (Direction) Random.Range(0,4);	
				  }
				  dirTimer = dirChangeTime;
				}
				else
				{
				  transform.Translate(-speed*Time.deltaTime,0f,0f,Space.World);
				}
			}
		}
		else
		{
			animation.wrapMode = WrapMode.Loop;
			animation.Play("Attack");
			
			attackTimer -= Time.deltaTime;
			tickTimer -= Time.deltaTime;
			if(tickTimer <= 0f)
			{
				hits.Clear();
				foreach(GameObject sp in checkSpheres)
					hitCheck(sp,hits);
				foreach(GameObject en in hits)
					(en.GetComponent(typeof(Stats)) as Stats).health -= 5;
				tickTimer = tickTimerMax;
				
			}
			if(attackTimer <= 0f)
			{
				targetFound = false;
				animation.wrapMode = WrapMode.Loop;
				animation.Play ("Move");
				particleSystem.Stop ();
				disableCheckSphereColliders();
			}
		}
	
		
		
	}
	
	private void hitCheck(GameObject sp, List<GameObject> hits)
	{
		foreach(Collider col in Physics.OverlapSphere(sp.transform.position,sp.collider.bounds.size.x/2f))
		{
			if(col.gameObject.CompareTag("Enemy") && !hits.Contains(col.gameObject))
				hits.Add(col.gameObject);
		}
	}
	
	private void disableCheckSphereColliders()
	{
		foreach(GameObject sp in checkSpheres)
			sp.collider.enabled = false;
	}
	private void enableCheckSphereColliders()
	{
		foreach(GameObject sp in checkSpheres)
			sp.collider.enabled = true;
	}
	
}
