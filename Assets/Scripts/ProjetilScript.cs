using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilScript : MonoBehaviour {

	public float speed;

	void Start () {
		// Destroy when projetil dont hit something
		Destroy (gameObject, 3.0f);
	}

	void OnCollisionEnter2D(Collision2D c){
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D c){
		// Destroy sub enemy
		if (c.tag == "SubInimigo") {
			Destroy (c.gameObject);
			Destroy (gameObject);
		}
	}

	void Update () {
		// Move object
		transform.Translate (Vector2.right * speed * Time.deltaTime);
	}
}
