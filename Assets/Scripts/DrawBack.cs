using UnityEngine;
using System.Collections;

public class DrawBack : MonoBehaviour {
	
	float timer;
	// Use this for initialization
	void Start () {
		timer = 6f;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer <= 0f)
			Application.LoadLevel("Title");
		transform.Translate(0f,0f,0.005f,Space.World);
		if(Input.GetKeyDown (KeyCode.Return))
		{
			Destroy (GameObject.Find ("levelHolder"));
			Destroy (GameObject.Find ("selectedClass"));

			Application.LoadLevel("Title");	
		}
	}
	
}
