using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Quad_Attributes : MonoBehaviour {

	// Use this for initialization
	float quadPos;

	GameObject SBParticles;
	//ParticleSystem SquareBubble;

	Color quadColor;

	GameObject gameController;

	void Awake () 
	{
		//SBParticles = GameObject.Find ("SquareBubble");
		//SquareBubble = SBParticles.GetComponent<ParticleSystem>();
		gameController = GameObject.Find ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//	void OnTriggerEnter (Collider col)
//	{
	//	if (col.tag == "Kubo") 
		//{
			//quadPos = transform.position.x;
			//SBParticles.transform.position = new Vector3 (quadPos, -0.15f, -1f);
			//quadColor = this.gameObject.GetComponent<MeshRenderer> ().material.color;
			//SquareBubble.startColor = quadColor;
			//gameController.GetComponent<Color_Collector> ().UparBarra (quadColor);
		//}
	//}
}
