using UnityEngine;
using System.Collections;

public class HealthPotionActivationScript : MonoBehaviour {
	public GameObject chara;
	public Stats charStats;
	// Use this for initialization
	void Start () {
		chara = GameObject.Find("Character");
		charStats = (Stats) chara.GetComponent (typeof(Stats));
		charStats.health += 25f;
		if(charStats.health>charStats.maxHealth)
			charStats.health = charStats.maxHealth;
		GameObject.Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
