using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
	
	public float health, maxHealth;
	public int damage,speed,wisdom,attackSpeed;
	void Start()
	{
		maxHealth = 100;
		health = maxHealth;
		damage = 3;
		speed = 200;
		wisdom = 3;
		attackSpeed = 3;
	}

}
