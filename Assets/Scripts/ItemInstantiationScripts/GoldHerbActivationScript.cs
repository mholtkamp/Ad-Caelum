using UnityEngine;
using System.Collections;

public class GoldHerbActivationScript : MonoBehaviour {
	public GameObject chara;
	public Stats charStats;
	private float timeStart, healInterval, healIntervalMax, maxHeal;
	// Use this for initialization
	void Start () {
		chara = GameObject.Find("Character");
		charStats = (Stats) chara.GetComponent (typeof(Stats));
		maxHeal = 50f;
		healInterval = 0.0f;
		healIntervalMax = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		timeStart -= Time.deltaTime;
		healInterval += Time.deltaTime;
		if(healInterval >= healIntervalMax)
		{
			charStats.health += 5f;
			if(charStats.health>charStats.maxHealth)
				charStats.health = charStats.maxHealth;
			maxHeal -= 5f;
			healInterval = 0f;
		}
		if(maxHeal <= 0)
		{
			GameObject.Destroy(gameObject);
		}		
	}
}
