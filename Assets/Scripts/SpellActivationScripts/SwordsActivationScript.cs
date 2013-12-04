using UnityEngine;
using System.Collections;

public class SwordsActivationScript : MonoBehaviour {

	float timer;
	GameObject chara;
	// Use this for initialization
	void Start () {
		timer = 10f;
		chara = GameObject.Find("Character");
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		transform.position = chara.transform.position;
		transform.Rotate (0f,180f*Time.deltaTime,0f);
		if(timer <= 0)
		{
			/*transform.
			//if(transform.FindChild("Sword1").gameObject != null)
				GameObject.Destroy (transform.FindChild ("Sword1").gameObject);
			if(transform.FindChild("Sword2").gameObject != null)
				GameObject.Destroy (transform.FindChild ("Sword2").gameObject);
			if(transform.FindChild("Sword3").gameObject != null)
				GameObject.Destroy (transform.FindChild ("Sword3").gameObject);
			if(transform.FindChild("Sword4").gameObject != null)
				GameObject.Destroy (transform.FindChild ("Sword4").gameObject);*/
			Destroy(gameObject);
		}
		
	}
}