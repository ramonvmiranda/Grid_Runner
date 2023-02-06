using UnityEngine;
using System.Collections;

public class Input_Controller : MonoBehaviour {
	
	Vector2 startPos;
	float swipeStartTime;
	public float minDist, maxTime;
	
	// Update is called once per frame
	void Update () {
		foreach (Touch touch in Input.touches) 
		{
			if (touch.phase == TouchPhase.Began) 
			{
				startPos = touch.position;
				swipeStartTime = Time.time; 
				Debug.Log ("Tocou");
			}

			float swipeTime = Time.time - swipeStartTime; //Time the touch stayed at the screen till now.
			float swipeDistX = Mathf.Abs (touch.position.x - startPos.x);
			float swipeDistY = Mathf.Abs (touch.position.y - startPos.y);


			if (touch.phase == TouchPhase.Ended)
			{
				Debug.Log ("Soltou");
				if (Mathf.Sign (touch.position.x - startPos.x) == 1f && swipeDistX >= minDist && swipeDistY < minDist) 
				{
					this.GetComponent<Rhythm_Controller> ().cmd = 3;
				}
				else if (Mathf.Sign (touch.position.x - startPos.x) == -1f && swipeDistX >= minDist && swipeDistY < minDist) 
				{
					this.GetComponent<Rhythm_Controller> ().cmd = 4;
				}
				else if (Mathf.Sign (touch.position.y - startPos.y) == 1f && swipeDistY >= minDist && swipeDistX < minDist) 
				{
					this.GetComponent<Rhythm_Controller> ().cmd = 1;
				}
				else if (Mathf.Sign (touch.position.y - startPos.y) == -1f && swipeDistY >= minDist && swipeDistX < minDist) 
				{
					this.GetComponent<Rhythm_Controller> ().cmd = 2;
				}
				else if (swipeDistX < minDist && swipeDistY < minDist && swipeTime < 0.5f)
				{
					this.GetComponent<Rhythm_Controller> ().cmd = 1;
				}
				else
				{
					this.GetComponent<Rhythm_Controller> ().cmd = 0;
				}
			}
		}
	}
}
