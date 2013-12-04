using UnityEngine;
using System.Collections;

public class camController : MonoBehaviour {
	
	//Camera Related Variables
	GameObject cam;
	Vector3 camPos;
	public float defaultHeight;
	public float zBuffer;
	
	
	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
		cam = GameObject.Find("Main Camera");
		defaultHeight = 3.5f;
		//cam.transform.position.y;
		zBuffer = 0.25f;
	}
	
	// Update is called once per frame
	void Update () {
		camPos = transform.position;
		camPos.y = defaultHeight;
		camPos.z = camPos.z - zBuffer;
		cam.transform.position = camPos;
	}
}
