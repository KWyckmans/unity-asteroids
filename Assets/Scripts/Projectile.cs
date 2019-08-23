using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour  {

	Rigidbody2D r2d;
	// Use this for initialization
	public float speed = 300.0f;

	private Vector2 screenBounds;

	void Awake() {
		r2d = GetComponent<Rigidbody2D>();
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		// r2d.velocity = Vector2.up * speed;
		Debug.Log("Screen bounds: " + screenBounds);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > screenBounds.x || transform.position.x < -screenBounds.x || transform.position.y > screenBounds.y || transform.position.y < -screenBounds.y){
			Destroy(gameObject);
		}	
	}

	public void Fire(Vector2 direction){
		r2d.AddForce(direction * speed);
	}
}
