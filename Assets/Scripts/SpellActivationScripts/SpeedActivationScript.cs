using UnityEngine;
using System.Collections;

public class SpeedActivationScript : MonoBehaviour {

	float timer;
	Stats charStats;
	GameObject chara;
	// Use this for initialization
	void Start () {
		timer = 6f;
		chara = GameObject.Find("Character");
		charStats = (Stats) chara.GetComponent (typeof(Stats));
		charStats.speed += 200;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		transform.position = chara.transform.position;
		if(timer <= 0)
		{
			charStats.speed -= 200;
			GameObject.Destroy (transform.FindChild ("Particle System").gameObject);
			Destroy(gameObject);
		}
		
	}
}
