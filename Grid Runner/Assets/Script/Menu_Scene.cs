using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu_Scene : MonoBehaviour {

	int nextSceneIndex;
	void Start ()
	{
		nextSceneIndex = SceneManager.GetActiveScene ().buildIndex + 1;
	}

	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) 
		{
			SceneManager.LoadScene (nextSceneIndex);
		}
	}
}
