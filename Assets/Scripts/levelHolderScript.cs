using UnityEngine;
using System.Collections;

public class levelHolderScript : MonoBehaviour {
	
	public int level;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		level = 1;
	}
	
}
