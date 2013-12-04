using UnityEngine;
using System.Collections;

public class FrostWallActivationScript : MonoBehaviour {
	
	float timer;
	GameObject chara;
	
	// Use this for initialization
	void Start () {
		
		timer = 7f;
		chara = GameObject.Find("Character");
		transform.position = chara.transform.position;
		transform.Translate(chara.transform.forward*1.5f);
		transform.Translate(0f,0.23f,0f);
		transform.forward = chara.transform.forward;
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer < 0)
		{
			GameObject.Destroy (transform.FindChild ("IceWallChild1").gameObject);
			GameObject.Destroy (transform.FindChild ("IceWallChild2").gameObject);
			GameObject.Destroy (transform.FindChild ("IceWallChild3").gameObject);
			GameObject.Destroy (transform.FindChild ("IceWallChild4").gameObject);
			GameObject.Destroy (transform.FindChild ("IceWallChild5").gameObject);
			Destroy(gameObject);
		}
	}
}
