using UnityEngine;
using System.Collections;

public class torpedoMovement : MonoBehaviour {
	public float moveTime, maxMoveTime, speed, collisionBuffer;
	private int currentDirection;
	private bool found;
	private RaycastHit colCast;
	private GameObject character;
	private Stats characterStats;
	private Stats stats;
	// Use this for initialization
	void Start () {
	  moveTime = 0f;
	  maxMoveTime = 1f;
	  found = false;
	  collisionBuffer = 0.001f;
	  character = GameObject.Find("Character");
	  characterStats = (Stats) character.GetComponent(typeof (Stats));
	  stats = (Stats) GetComponent (typeof(Stats));
	  stats.speed = 100;
	  currentDirection = 0;
	}
	
	// Update is called once per frame
	void Update () {
	  speed = (float) stats.speed/100f;
	  if(stats.health <= 0)
			Destroy(gameObject);
	  moveTime += Time.deltaTime;
	  if(moveTime >= maxMoveTime)
	  {
		moveTime = 0f;
		currentDirection = Random.Range(0,4);
		if(found)
		  found = false;				
	  }
	  
	  //search for character
    if(!found)
	{
	  if(Physics.Raycast(transform.position,Vector3.forward,out colCast, 2f))
	  {
		if(colCast.collider.gameObject.Equals(character))
		{
	      found = true;
	      currentDirection = 0;
		  moveTime = 0f;
		}
	  }
	  if(Physics.Raycast(transform.position,Vector3.right,out colCast, 2f))
	  {
		if(colCast.collider.gameObject.Equals(character))
		{
	      found = true;
	      currentDirection = 1;
		  moveTime = 0f;
		}
      }
      if(Physics.Raycast(transform.position,Vector3.back,out colCast, 2f))
	  {
		if(colCast.collider.gameObject.Equals(character))
		{
	      found = true;
	      currentDirection = 2;
		  moveTime = 0f;
		}
	  }
	  if(Physics.Raycast(transform.position,Vector3.left,out colCast, 2f))
	  {
		if(colCast.collider.gameObject.Equals(character))
		{
	      found = true;
	      currentDirection = 3;
		  moveTime = 0f;
		}
      }
	}

      //print(found);
		

	  if(!found)//just do casual moving
	  {
			if(currentDirection == 0)//move north
			{
				if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.forward,out colCast,speed*Time.deltaTime))
				{
				  transform.Translate (0f,0f,colCast.distance - collisionBuffer,Space.World);
				  currentDirection = Random.Range(1,4);	
				  moveTime = 0f;
				}
				else
				{
				  transform.Translate(0f,0f,speed*Time.deltaTime,Space.World);
				}
			}
			else if(currentDirection == 1)//move east
			{
				if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.right,out colCast,speed*Time.deltaTime))
				{
				  transform.Translate (colCast.distance - collisionBuffer,0f,0f,Space.World);
				  while(currentDirection == 1)
				  {
				    currentDirection = Random.Range(0,4);	
				  }
			      moveTime = 0f;
				}
				else
				{
				  transform.Translate(speed*Time.deltaTime,0f,0f,Space.World);
				}  				
			}
			else if(currentDirection == 2)//move south
			{
				if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.back,out colCast,speed*Time.deltaTime))
				{
				  transform.Translate (0f,0f,-colCast.distance + collisionBuffer,Space.World);
				  while(currentDirection == 2)
				  {
				    currentDirection = Random.Range(0,4);	
				  }
				  moveTime = 0f;
				}
				else
				{
				  transform.Translate(0f,0f,-speed*Time.deltaTime,Space.World);
				}  	
				
			}
			else//move west
			{
				if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.left,out colCast,speed*Time.deltaTime))
				{
				  transform.Translate (-colCast.distance + collisionBuffer,0f,0f,Space.World);
				  while(currentDirection == 3)
				  {
				    currentDirection = Random.Range(0,4);	
				  }
			      moveTime = 0f;
				}
				else
				{
				  transform.Translate(-speed*Time.deltaTime,0f,0f,Space.World);
				}
			}
	  }
	  else//meaning it is found
	  {
			if(currentDirection == 0)//move north
			{
				if(Physics.Raycast(transform.position,Vector3.forward,out colCast, 4f*speed*Time.deltaTime))
	 			{
				  if(colCast.collider.gameObject.Equals(character))
				  {
				    characterStats.health -= 1f;
				  }
				}
				if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.forward,out colCast,3f*speed*Time.deltaTime))					
				{
				  transform.Translate (0f,0f,colCast.distance - collisionBuffer,Space.World);
				  //currentDirection = Random.Range(1,4);	
				  //moveTime = 0f;
				}
				else
				{
				  transform.Translate(0f,0f,3f*speed*Time.deltaTime,Space.World);
				}
			}
			else if(currentDirection == 1)//move east
			{
				if(Physics.Raycast(transform.position,Vector3.right,out colCast, 4f*speed*Time.deltaTime))
	 			{
				  if(colCast.collider.gameObject.Equals(character))
				  {
				    characterStats.health -= 1f;
				  }
				}
				if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.right,out colCast,3f*speed*Time.deltaTime))
				{
				  transform.Translate (colCast.distance - collisionBuffer,0f,0f,Space.World);
				  /*while(currentDirection == 1)
				  {
				    currentDirection = Random.Range(0,4);	
				  }
			      moveTime = 0f;*/
				}
				else
				{
				  transform.Translate(3f*speed*Time.deltaTime,0f,0f,Space.World);
				}  				
			}
			else if(currentDirection == 2)//move south
			{
				if(Physics.Raycast(transform.position,Vector3.back,out colCast, 4f*speed*Time.deltaTime))
	 			{
				  if(colCast.collider.gameObject.Equals(character))
				  {
				    characterStats.health -= 1f;
				  }
				}
				if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.back,out colCast,3f*speed*Time.deltaTime))
				{
				  transform.Translate (0f,0f,-colCast.distance + collisionBuffer,Space.World);
				  /*while(currentDirection == 2)
				  {
				    currentDirection = Random.Range(0,4);	
				  }
				  moveTime = 0f;*/
				}
				else
				{
				  transform.Translate(0f,0f,-3f*speed*Time.deltaTime,Space.World);
				}  	
				
			}
			else//move west
			{
				if(Physics.Raycast(transform.position,Vector3.left,out colCast, 4f*speed*Time.deltaTime))
	 			{
				  if(colCast.collider.gameObject.Equals(character))
				  {
				    characterStats.health -= 1f;
				  }
				}
				if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.left,out colCast,3f*speed*Time.deltaTime))
				{
				  transform.Translate (-colCast.distance + collisionBuffer,0f,0f,Space.World);
				  /*while(currentDirection == 3)
				  {
				    currentDirection = Random.Range(0,4);	
				  }
			      moveTime = 0f;*/
				}
				else
				{
				  transform.Translate(-3f*speed*Time.deltaTime,0f,0f,Space.World);
				}
			}
	  }	
		
	  if(currentDirection == 0)
	  {
			transform.forward = Vector3.forward;
	  }
	  if(currentDirection == 1)
	  {
			transform.forward = Vector3.right;
	  }
	  if(currentDirection == 2)
	  {
			transform.forward = Vector3.back;
	  }
	  if(currentDirection == 3)
	  {
			transform.forward = Vector3.left;
	  }		
	}
}
