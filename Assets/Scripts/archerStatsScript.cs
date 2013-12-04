using UnityEngine;
using System.Collections;

public class archerStatsScript : MonoBehaviour {
	Stats archerStats; 
	// Use this for initialization
	void Start () {
	    archerStats = (Stats) transform.gameObject.GetComponent(typeof(Stats));
	    archerStats.maxHealth = 90;
		archerStats.health = 90;
		archerStats.damage = 2;
		archerStats.wisdom = 4;
		archerStats.speed = 220;
	}
	
	// Update is called once per frame
	void Update () 
	{
	  if(archerStats.initialized == false)
		{
			archerStats.maxHealth = 90;
			archerStats.health = 90;
			archerStats.damage = 2;
			archerStats.wisdom = 4;
			archerStats.speed = 220;
			archerStats.initialized = true;
		}
	}
}