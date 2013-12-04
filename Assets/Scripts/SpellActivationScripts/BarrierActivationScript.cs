using UnityEngine;
using System.Collections;

public class BarrierActivationScript : MonoBehaviour {

	GameObject chara;
	Stats stats;
	selectedClassScript css;
	charController charcon;
	archerController arcon;
	wizardController wizcon;
	
	float duration;
	float healthmin;
	
	void Start () {
		chara = GameObject.Find ("Character");
		stats = chara.GetComponent(typeof(Stats)) as Stats;
		css = (selectedClassScript) GameObject.Find ("selectedClass").GetComponent(typeof(selectedClassScript));
		if(css.selectedClass == 0)
		{
		  charcon = chara.GetComponent(typeof(charController)) as charController;
		}
		else if(css.selectedClass == 1)
		{
		  arcon = chara.GetComponent(typeof(archerController)) as archerController;	
		}
		else
		{
		  wizcon = chara.GetComponent(typeof(wizardController)) as wizardController;	
		}
		
		duration = 1.5f;
		healthmin = stats.health;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		duration -= Time.deltaTime;
		if(duration <= 0f)
		{
			if(css.selectedClass == 0)
			{
			  charcon.invincible = false;	
			}
			else if(css.selectedClass == 1)
			{
			  arcon.invincible = false;		
			}
			else
			{
			  wizcon.invincible = false;		
			}
			
			Destroy (gameObject);
		}
		else
		{
			if(css.selectedClass == 0)
			{
			  charcon.invincible = true;	
			}
			else if(css.selectedClass == 1)
			{
			  arcon.invincible = true;		
			}
			else
			{
			  wizcon.invincible = true;		
			}
			//charcon.invincible = true;
			if(stats.health < healthmin)
				stats.health = healthmin;
			else if(stats.health > healthmin)
				healthmin = stats.health;
		}
		
		transform.position = chara.transform.position;
	}
}
