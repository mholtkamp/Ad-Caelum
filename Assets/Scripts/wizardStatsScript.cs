using UnityEngine;
using System.Collections;

public class wizardStatsScript : MonoBehaviour {
	Stats wizardStats;
	// Use this for initialization
	void Start () {
	    wizardStats = (Stats) transform.gameObject.GetComponent(typeof(Stats));
	    wizardStats.maxHealth = 80;
		wizardStats.health = 80;
		wizardStats.damage = 0;
		wizardStats.wisdom = 6;
		wizardStats.speed = 180;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
