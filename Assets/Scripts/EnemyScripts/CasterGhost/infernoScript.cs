using UnityEngine;
using System.Collections;

public class infernoScript : MonoBehaviour {
	float timer;
	float damage;
	bool exploded;
	bool contacted;
	GameObject infexp;
	Collider[] colHits;
	// Use this for initialization
	void Start () {
		timer = 1.2f;
		exploded = false;
		contacted = false;
		damage = 30f;
	}
	
	// Update is called once per frame
	void Update () {
		
		timer -= Time.deltaTime;
		
		if(timer <= 0f)
		{
			if(!exploded)
			{
				(infexp = Instantiate(Resources.Load ("infexp")) as GameObject).transform.position = transform.position;
				exploded = true;
			}
			else
			{
				if(!contacted)	
				{
					colHits = Physics.OverlapSphere(transform.position,transform.collider.bounds.size.x/2);
					for(int i = 0; i < colHits.Length;i++)
					{
						if(colHits[i].gameObject.name == "Character")
						{
							contacted = true;
							(colHits[i].collider.gameObject.GetComponent(typeof(Stats)) as Stats).health -= damage;
						}
					}
				}
				if(infexp == null)
					Destroy (gameObject);
			}
		}
	
	}
}
