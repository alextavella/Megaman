using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

	public GameObject projetilPrefab;
	public GameObject sensorRotation;
	
	// Update is called once per frame
	void Update () {
		
		// fire
		if (Input.GetButtonDown ("Fire1")) {
			Instantiate (projetilPrefab, transform.position, transform.rotation);
		}

		// rotation
		if (Input.GetAxisRaw ("Horizontal") > 0.0f) {
			sensorRotation.transform.eulerAngles = new Vector3 (0.0f, 0.0f, 0.0f);
		} else if (Input.GetAxisRaw ("Horizontal") < 0.0f) {
			sensorRotation.transform.eulerAngles = new Vector3 (0.0f, 180.0f, 0.0f);
		}
	}
}
