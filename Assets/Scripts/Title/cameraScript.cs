using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {
	startButtonScript start;
	exitButtonScript exit;
	titleScript title;
	wizardButtonScript wiz;
	warriorButtonScript war;
	archerButtonScript arc;
	classTextScript cts;
	int state ;
	
	//State 1 vars
	float xdisthalf;
	float xvel;
	float xacc;
	
	//State 2 vars
	float xrotdiff;
	float yrotdiff;
	
	//state 4 vars
	Vector3 source;
	Vector3 dest;
	
	// Use this for initialization
	void Start () {
		start = GameObject.Find ("Start").GetComponent (typeof(startButtonScript)) as startButtonScript;
		exit = GameObject.Find ("Exit").GetComponent (typeof(exitButtonScript)) as exitButtonScript;
		title = GameObject.Find ("Title").GetComponent (typeof(titleScript)) as titleScript;
		wiz = GameObject.Find ("WizardButton").GetComponent (typeof(wizardButtonScript)) as wizardButtonScript;
		war = GameObject.Find ("WarriorButton").GetComponent (typeof(warriorButtonScript)) as warriorButtonScript;
		arc = GameObject.Find ("ArcherButton").GetComponent (typeof(archerButtonScript)) as archerButtonScript;
		cts = GameObject.Find ("ClassText").GetComponent(typeof(classTextScript)) as classTextScript;
		state = 0;
	}

	// Update is called once per frame
	void Update () {
		if(state == 0)
		{
			if((start.faded)&&(exit.faded)&&(title.faded))
			{
				Destroy(start.gameObject);
				Destroy(exit.gameObject);
				Destroy(title.gameObject);
				xdisthalf = (85.81f - transform.position.x)/2;
				xvel = 0f;
				xacc = 0.001f;
				state = 1;
			}
		}
		else if(state == 1)
		{
			StartCoroutine ("approachCastle");
			
			
		}
		else if(state == 2)
		{
			Vector3 newRot = transform.localEulerAngles;
			if((transform.localEulerAngles.x > 314f) || (transform.localEulerAngles.y > 44.7f))
			{
				if((transform.localEulerAngles.x > 314f))
					newRot.x -= xrotdiff*Time.deltaTime;
				if((transform.localEulerAngles.y > 44.7f))
					newRot.y -= yrotdiff*Time.deltaTime;
				
				if(newRot.x < 314f)
					newRot.x = 313.8f;
				if(newRot.y < 44.7f)
					newRot.y = 44.6f;
				
				transform.localEulerAngles = newRot;
			}
			else
			{
				wiz.show();
				arc.show();
				war.show();
				cts.show();

				state = 3;
			}
		}
		else if(state == 3)
		{
			if(wiz.faded && war.faded && arc.faded && cts.faded)
			{
				Destroy (wiz.gameObject);
				Destroy (war.gameObject);
				Destroy (arc.gameObject);
				Destroy (cts.gameObject);
				
				source = transform.position;
				dest = new Vector3(83.6f,13.8f,-68.5f);
				xrotdiff = 352.8f - transform.localEulerAngles.x;
				yrotdiff = 91.8f - transform.localEulerAngles.y;
				state = 4;
			}
		}
		else if(state == 4)
		{
			
			Vector3 newRot = transform.localEulerAngles;
			Vector3 newPos = transform.position;
			if((transform.position.x > 83.6f) || (transform.position.y < 13.8f) || (transform.position.z > -68.5f))
				repoCam (dest,source);
			if((transform.localEulerAngles.x < 352.8f) || (transform.localEulerAngles.y < 91.7f))
			{
				if((transform.localEulerAngles.x < 352.8f))
					newRot.x += xrotdiff*Time.deltaTime;
				if((transform.localEulerAngles.y < 91.7f))
					newRot.y += yrotdiff*Time.deltaTime;
				
				if(newRot.x > 352.8f)
					newRot.x = 352.9f;
				if(newRot.y > 91.7f)
					newRot.y = 91.8f;
				
				transform.localEulerAngles = newRot;
			}
			else
			{
				state = 5;
			}
			
			
			

		}
		
		
		
		
	}
	
	IEnumerator approachCastle()
	{
		while(transform.position.x < 85.81f)
		{			
			if(transform.position.x < xdisthalf)
				xvel += xacc;
			else
				xvel -= xacc/2;
			
			Vector3 newPos = transform.position;
			newPos.x = transform.position.x + xvel*Time.deltaTime;
			transform.position = newPos;
			if(transform.position.x > 85.81f)
			{
				newPos.x = 85.82f;
				transform.position = newPos;
			}
			
			yield return 0;
				
		}
		
		xrotdiff = transform.localEulerAngles.x - 314f;
		yrotdiff = transform.localEulerAngles.y - 44.7f;
		state = 2;
	
		
	}
	
	
	void repoCam(Vector3 dest, Vector3 source)
	{
		Vector3 diff = (dest - source)*Time.deltaTime;
		transform.Translate (diff,Space.World);
	}
}
