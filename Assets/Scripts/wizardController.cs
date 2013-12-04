using UnityEngine;
using System.Collections;


public class wizardController : MonoBehaviour {
	

	private RaycastHit colCast;
	
	public float speed;
	public float collisionBuffer;
	Stats stats;
	private int animationSelector;
	public float attackTimer, attackBuffer;
	private bool notAttacking;
	private GameObject wizard;
	private Stats enemyStats, chestStats;
	private bool noDamageYet;
	
	public bool immobile;
	public bool disarmed;
	public bool silenced;
	public bool invincible;	
	
	// Use this for initialization
	void Start () {	
		stats = (Stats) (GetComponent(typeof(Stats)));
		speed = (float) (stats.speed/100f);
		collisionBuffer = 0.001f;
		colCast = new RaycastHit();
		animationSelector = 0;
		attackTimer = 0f;
		notAttacking = true;
		wizard = GameObject.Find("wizard");
		noDamageYet = true;
		attackBuffer = .1f;
//		animation.Play("Take 001");
	}
	
	// Update is called once per frame
	void Update () {
		if(stats.health <= 0f)
			Application.LoadLevel("gameover");
		if(animationSelector == 0)
			wizard.animation.Play("stand", PlayMode.StopAll);
		else
			wizard.animation.Play("walk", PlayMode.StopAll);

		
		if(Input.GetMouseButtonDown(0) && notAttacking)
		{
			attackTimer = .5f;
			notAttacking = false;
			noDamageYet = true;
		}
		if(attackTimer > 0 && (attackTimer < .5f - attackBuffer))
		{
			if(noDamageYet)
			{
			  if(Physics.Raycast(transform.position-transform.right*0.3f,transform.forward,out colCast,0.6f))
			  {
				if(colCast.collider.tag.Equals("Chest")&&noDamageYet)
				{
					chestStats = (Stats) colCast.collider.gameObject.GetComponent(typeof(Stats));
					//	print ("HIT THE ENEMY!");
					chestStats.health -= 101f;
					noDamageYet = false;	
				}
			  }
			}
			if(noDamageYet)
			{
			  if(Physics.Raycast(transform.position,transform.forward,out colCast,0.6f))
			  {
				if(colCast.collider.tag.Equals("Chest")&&noDamageYet)
				{
					chestStats = (Stats) colCast.collider.gameObject.GetComponent(typeof(Stats));
					//	print ("HIT THE ENEMY!");
					chestStats.health -= 101f;
					noDamageYet = false;	
				}
			  }
			}
			if(noDamageYet)
			{
			  if(Physics.Raycast(transform.position+transform.right*0.35f,transform.forward,out colCast,0.6f))
			  {
				if(colCast.collider.tag.Equals("Chest")&&noDamageYet)
				{
					chestStats = (Stats) colCast.collider.gameObject.GetComponent(typeof(Stats));
					//	print ("HIT THE ENEMY!");
					chestStats.health -= 101f;
					noDamageYet = false;	
				}
			  }
			}
			attackTimer -= Time.deltaTime;
		}
		if(attackTimer > .35f )
			attackTimer -= Time.deltaTime;
		if(attackTimer <= 0)
		{	
			notAttacking = true;
		}
		
		
		speed = (float) (stats.speed/100f);
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W)
			|| Input.GetKey(KeyCode.S))
		{
			animationSelector = 1;	
		}
		else
		{
			animationSelector = 0;	
		}
		
		
		int inputCount = 0;
		if(Input.GetKey (KeyCode.A))
			++inputCount;
		if(Input.GetKey (KeyCode.W))
			++inputCount;
		if(Input.GetKey (KeyCode.S))
			++inputCount;
		if(Input.GetKey (KeyCode.D))
			++inputCount;

		if(inputCount >= 2)
			speed = speed*(1f/Mathf.Sqrt(2f));		
		
		//Handle Input
		if(!immobile)
		{
			if(Input.GetKey(KeyCode.A))
			{
				if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.left,out colCast,speed*Time.deltaTime))
					transform.Translate (-colCast.distance + collisionBuffer,0f,0f,Space.World);
				else
					transform.Translate(-speed*Time.deltaTime,0f,0f,Space.World);
	
			}
			if(Input.GetKey(KeyCode.D))
			{
				if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.right,out colCast,speed*Time.deltaTime))
					transform.Translate (colCast.distance - collisionBuffer,0f,0f,Space.World);
	
				else
					transform.Translate(speed*Time.deltaTime,0f,0f,Space.World);
	
			}
			if(Input.GetKey(KeyCode.W))
			{
				if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.z/2,Vector3.forward,out colCast,speed*Time.deltaTime))
					transform.Translate (0f,0f,colCast.distance - collisionBuffer,Space.World);
				else
					transform.Translate(0f,0f,speed*Time.deltaTime,Space.World);
			}
			if(Input.GetKey(KeyCode.S))
			{
				if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.z/2,Vector3.back,out colCast,speed*Time.deltaTime))
					transform.Translate (0f,0f,-colCast.distance + collisionBuffer,Space.World);
	
				else
					transform.Translate(0f,0f,-speed*Time.deltaTime,Space.World);
			}
		
		}
			
	}
}
