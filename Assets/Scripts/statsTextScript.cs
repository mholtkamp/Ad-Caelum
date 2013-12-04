using UnityEngine;
using System.Collections;

public class statsTextScript : MonoBehaviour {

	public float x,y;
	int defaultFontSize;
	GameObject character;
	Stats stats;
	// Use this for initialization
	void Start () {
		character = GameObject.Find ("Character");
		stats = (Stats) character.GetComponent ("Stats");
		x = 0.25f;
		y = 0.465f;
		defaultFontSize = 18;
		guiText.pixelOffset = new Vector2(Screen.width*x,Screen.height*y);
		guiText.fontSize = defaultFontSize;
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Health: (" + stats.health + "/" + stats.maxHealth +")\n" +
			"Damage: " + stats.damage + "    Speed: " + stats.speed + "\n" +
			"Wisdom: " + stats.wisdom + "    Attack Speed: " + stats.attackSpeed;
		

	}
}
