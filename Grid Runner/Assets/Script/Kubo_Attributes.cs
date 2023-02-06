using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Kubo_Attributes : MonoBehaviour {

	public float[] cor = new float[] {0f, 0f, 0f};
	float avanco;
	public int i;

	Color kuboCor;

	Image bg;

	void Start ()
	{
		bg = GameObject.Find ("BG").GetComponent<Image> (); 
		bg.color = new Color (0.5f, 0.5f, 0.5f, 0f);
	}

	// Update is called once per frame
	void Update () 
	{
		kuboCor = new Color (cor[0], cor[1], cor[2], 1f);
		avanco = (cor [0] + cor [1] + cor [2]) / 3;
		bg.color = new Color (0.5f, 0.5f, 0.5f, avanco); 
	}

	public void ganhaCor (int i)
	{
		cor[i] += 0.0370f; 
		this.gameObject.GetComponent<MeshRenderer> ().material.color = kuboCor;
	}

	public int MatchColorRhythm ()
	{

		if (avanco > 0f && avanco <= 0.077f) 
		{
			i = 0;
		}
		else if (avanco > 0.077f && avanco <= 0.154f) 
		{
			i = 1;
		}
		else if (avanco > 0.154f && avanco <= 0.231f) 
		{
			i = 2;
		}
		else if (avanco > 0.231f && avanco <= 0.308f) 
		{
			i = 3;
		}
		else if (avanco > 0.308f && avanco <= 0.385f) 
		{
			i = 4;
		}
		else if (avanco > 0.385f && avanco <= 0.462f) 
		{
			i = 5;
		}
		else if (avanco > 0.462f && avanco <= 0.539f) 
		{
			i = 6;
		}
		else if (avanco > 0.539f && avanco <= 0.616f) 
		{
			i = 7;
		}
		else if (avanco > 0.616f && avanco <= 0.77f) 
		{
			i = 8;
		}
		else if (avanco > 0.77f && avanco <= 0.847f) 
		{
			i = 9;
		}
		else if (avanco > 0.847f && avanco <= 0.924f) 
		{
			i = 10;
		}
		else if (avanco > 0.924f && avanco <= 0.975f) 
		{
			i = 11;
		}
		else if (avanco > 0.975f && avanco <= 1f) 
		{
			i = 12;
		}
		return i;
	}
}
