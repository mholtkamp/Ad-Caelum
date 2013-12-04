using UnityEngine;
using System.Collections;

public class spinScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0f,360f*Time.deltaTime,0f);
	
	}
}
