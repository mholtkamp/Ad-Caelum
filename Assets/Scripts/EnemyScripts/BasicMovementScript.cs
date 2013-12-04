using UnityEngine;
using System.Collections;

public class BasicMovementScript : MonoBehaviour {
	
	GameObject chara;
	private bool targetAcquired;
	private Vector3 targVect;
	private RaycastHit colCast;
	private RaycastHit eCast;
	Stats stats;
	float collisionBuffer = 0.001f;
	float speed;
	bool isEnabled;
	private Vector3 initPos;
	
	void Start () {
		chara = GameObject.Find ("Character");
		targetAcquired = false;
		targVect = new Vector3();
		colCast = new RaycastHit();
		stats = (Stats) GetComponent (typeof(Stats));
		isEnabled = true;
		
	}
	
	void Update () {
		
		if(isEnabled)
		{
			search();
			if(targetAcquired)
				move();
			transform.LookAt (chara.transform);
			animate();
		}

	}
	
	private void search()
	{
		targVect.x = chara.transform.position.x - transform.position.x;
		targVect.z = chara.transform.position.z - transform.position.z;
		if(targetAcquired)
			return;
		else
		{
			Physics.Raycast (transform.position, targVect, out colCast,targVect.magnitude);
			if(colCast.transform.gameObject == chara)
			{
				targetAcquired = true;
				print ("TARGET FOUND");
			}
		}
	}
	
	private void move()
	{
			initPos = transform.position;
		
			speed = (float) (stats.speed/100f);
			if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,new Vector3(Mathf.Sign (targVect.x),0,0),out colCast,speed*Time.deltaTime))
				transform.Translate (Mathf.Sign(targVect.x)*colCast.distance + -1f*Mathf.Sign(targVect.x)*collisionBuffer,0f,0f,Space.World);
			else
				transform.Translate((targVect.x/targVect.magnitude)*speed*Time.deltaTime,0f,0f,Space.World);
		
			if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,new Vector3(0,0,Mathf.Sign (targVect.z)),out colCast,speed*Time.deltaTime))
				transform.Translate (0f,0f,Mathf.Sign(targVect.z)*colCast.distance + -1f*Mathf.Sign(targVect.z)*collisionBuffer,Space.World);
			else
				transform.Translate(0f,0f,(targVect.z/targVect.magnitude)*speed*Time.deltaTime,Space.World);
		
		foreach( Collider col in Physics.OverlapSphere (transform.position,transform.collider.bounds.size.x/2))
		{
			if(col.CompareTag ("Enemy") && (col.gameObject != gameObject))
			{
				transform.position = initPos;
				break;
			}
		}
		
	}
	
	private void animate()
	{
		if(!targetAcquired)
			animation.Play ("Idle");
		else
			animation.Play ("Move");
	}
	
	public void disable()
	{
		isEnabled = false;
	}
	
	public void enable()
	{
		isEnabled = true;
	}
	
}
