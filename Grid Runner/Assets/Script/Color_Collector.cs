using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Color_Collector : MonoBehaviour {

	public List<GameObject> redList = new List<GameObject>();
	public List<GameObject> greenList = new List<GameObject>();
	public List<GameObject> blueList = new List<GameObject>();

	public GameObject[] bars;

	Color red = new Color (1f, 0f, 0f, 1f);
	Color green = new Color (0f, 1f, 0f, 1f);
	Color blue = new Color (0f, 0f, 1f, 1f);
	Color black = new Color (0f, 0f, 0f, 1f);

	public GameObject[] blocks;

	public GameObject kubo;

	public void UparBarra (Color cor)
	{
		float xpos; 
		if (cor == red) {
			if (redList.Count <= 26f) 
			{
				xpos = redList.Count * 10 + 6;
//				redList.Add (blocks[0]);
				Transform redBar = bars[0].transform;
				GameObject block = Instantiate (blocks[0]) as GameObject;
				block.transform.position = new Vector3 (xpos, 0, 0);
				block.transform.SetParent (redBar, false);
				redList.Add (block);
				kubo.GetComponent<Kubo_Attributes> ().ganhaCor (0);
			}
		}
		else if (cor == green) 
		{
			if (greenList.Count <= 26f) 
			{
				xpos = greenList.Count * 10 + 6;
//				greenList.Add (blocks[1]);
				Transform greenBar = bars[1].transform;
				GameObject block = Instantiate (blocks[1]) as GameObject;
				block.transform.position = new Vector3 (xpos, 0, 0);
				block.transform.SetParent (greenBar, false);
				greenList.Add (block);
				kubo.GetComponent<Kubo_Attributes> ().ganhaCor (1);
			}
		}
		else if (cor == blue) 
		{
			if (blueList.Count <= 26f) 
			{
				xpos = blueList.Count * 10 + 6;
//				blueList.Add (blocks[2]);
				Transform blueBar = bars[2].transform;
				GameObject block = Instantiate (blocks[2]) as GameObject;
				block.transform.position = new Vector3 (xpos, 0, 0);
				block.transform.SetParent (blueBar, false);
				blueList.Add (block);
				kubo.GetComponent<Kubo_Attributes> ().ganhaCor (2);
			}
		}
		else if (cor == black) 
		{
			foreach (GameObject b in redList) 
			{
				Destroy (b);
			}
			foreach (GameObject b in greenList) 
			{
				Destroy (b);
			}
			foreach (GameObject b in blueList) 
			{
				Destroy (b);
			}

			redList.Clear ();
			greenList.Clear ();
			blueList.Clear ();

			kubo.GetComponent<Kubo_Attributes> ().cor [0] = 0f;
			kubo.GetComponent<Kubo_Attributes> ().cor [1] = 0f;
			kubo.GetComponent<Kubo_Attributes> ().cor [2] = 0f;
		}
	}
}
