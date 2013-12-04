using UnityEngine;
using System.Collections;

public class DunGenCam : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.A))
			transform.Translate (-0.2f,0f,0f);
		if(Input.GetKey (KeyCode.D))
			transform.Translate (0.2f,0f,0f);
		if(Input.GetKey (KeyCode.W))
			transform.Translate (0f,0.2f,0f);
		if(Input.GetKey (KeyCode.S))
			transform.Translate (0f,-0.2f,0f);
	}
}
