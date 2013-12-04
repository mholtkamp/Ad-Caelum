using UnityEngine;
using System.Collections;

public class selectedClassScript : MonoBehaviour {
	public int selectedClass;
	public int difficulty;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
