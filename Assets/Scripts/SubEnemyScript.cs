using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubEnemyScript : MonoBehaviour {

	public GameObject target;
	public float speed;

	private SpriteRenderer spriteRenderer;

	void Start () {

		spriteRenderer = GetComponent<SpriteRenderer>();

		// Set target
		target = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void Update () {

		transform.position = Vector2.Lerp (
			transform.position,
			target.transform.position,
			speed * Time.deltaTime
		);

		spriteRenderer.flipX = (transform.position.x < target.transform.position.x);
	}

	void OnCollision2D(Collision2D c){
		if (c.collider.tag == "Fire") {
			Destroy (gameObject);
		}
	}
}
