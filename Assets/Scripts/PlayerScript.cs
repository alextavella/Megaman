using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public float weight;

	public Transform chaoVerificador;

	private SpriteRenderer spriteRenderer;
	private Rigidbody2D rb;
	private Animator animator;

	private bool isColliderPiso;
	private int life = 5;

	// Use this for initialization
	void Start () {

		// Interface for components
		spriteRenderer = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Move
		float move_x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
		transform.Translate (move_x, 0.0f, 0.0f);

		// Animator running
		animator.SetFloat ("pRunning", Math.Abs(move_x));

		// Verify collision with 'piso'
		isColliderPiso = Physics2D.Linecast(
			transform.position,
			chaoVerificador.position, 
			1 << LayerMask.NameToLayer("Piso")
		);

		// Orientation view
		if (move_x > 0) { 
			spriteRenderer.flipX = false;
		} else if (move_x < 0) {
			spriteRenderer.flipX = true;
		}

		// Jump
		animator.SetBool ("pJumping", !isColliderPiso);

		if (Input.GetButtonDown ("Jump") && isColliderPiso) {
			rb.velocity = new Vector2 (0.0f, weight);
		}

		// Fire
		animator.SetBool ("pFire", Input.GetButton("Fire1"));

		// Dead
		if (life <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D c){
		// Destroy sub enemy
		if (c.tag == "SubInimigo") {
			Destroy (c.gameObject);
			life--;
		}
	}
}
