using UnityEngine;
using System.Collections;

public class staircaseScript : MonoBehaviour {
	GameObject chara;
	levelHolderScript lh;
	Collider[] overlaps;
	// Use this for initialization
	void Start () {
		chara = GameObject.Find("Character");
		lh = GameObject.Find ("LevelHolder").GetComponent(typeof(levelHolderScript)) as levelHolderScript;

	
	}
	
	// Update is called once per frame
	void Update () {
		overlaps = Physics.OverlapSphere(collider.bounds.center,collider.bounds.size.x/2);
		foreach(Collider col in overlaps)
		{
			if(col.gameObject == chara)
			{
				lh.level++;
				Application.LoadLevel("lvl1");
			}
		}
	}
}
