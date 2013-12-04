using UnityEngine;
using System.Collections;

public class castleScript : MonoBehaviour {

	Vector3 pos,newPos;
	float time;
	public float amp;
	void Start () {
		pos = new Vector3();
		newPos = new Vector3();
		pos.x = transform.position.x;
		pos.y = transform.position.y;
		pos.z = transform.position.z;
		time = 0f;
		amp = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		newPos.x = pos.x;
		newPos.y = pos.y;
		newPos.z = pos.z;
		newPos.y += Mathf.Sin (time);
		transform.position = newPos;
	
	}
}
