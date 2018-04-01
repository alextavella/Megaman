using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlinkScript : MonoBehaviour {

	public float interval;

	// Use this for initialization
	IEnumerator Start()
	{	
		// Get component of object
		GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds(interval);

		GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds(interval);

		// Do loop request for render
		StartCoroutine(Start());
	}

	void Update() {

		// Press enter key
		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene("GameScene");
		}
	}
}
