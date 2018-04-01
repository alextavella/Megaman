using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public int life;
	public GameObject subEnemyPrefab;
	public Transform generateFish;
	public float intervalo; 

	// Use this for initialization
	IEnumerator Start () {

		Instantiate (
			subEnemyPrefab, 
			generateFish.position, 
			generateFish.rotation);

		yield return new WaitForSeconds (intervalo);
		StartCoroutine (Start ());
	}

	void OnCollisionEnter2D(Collision2D c){
		// Lose life when attacked
		if (c.gameObject.tag == "Projetil") {
			life--;
		}
	}

	void Update () {
		print ("enemy life: " + life);
		// Destroy the enemy when life end
		if (life <= 0) {
			Destroy (gameObject);
		}
	}
}
