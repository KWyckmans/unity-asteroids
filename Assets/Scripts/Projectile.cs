using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour  {

	private Rigidbody2D r2d;
	// Use this for initialization
	public float speed = 10.0f;

	void Awake() {
		r2d = GetComponent<Rigidbody2D>();
	}

	void Start () {
		// r2d.velocity = Vector2.up * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Fire(Vector2 direction){
		Debug.Log("Firing at " + direction);
		Debug.Log("Test firing at " + Vector2.up * speed);
		r2d.AddForce(direction);
	}
}
