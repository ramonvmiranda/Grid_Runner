using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene_Wait : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("Wait");
	}

	IEnumerator Wait ()
	{
		yield return new WaitForSeconds(3);
		int nextSceneIndex = SceneManager.GetActiveScene ().buildIndex + 1;
		SceneManager.LoadScene (nextSceneIndex);
	}
}
