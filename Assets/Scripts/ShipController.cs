﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    KeyCode forward = KeyCode.UpArrow;
    KeyCode left = KeyCode.LeftArrow;
    KeyCode right = KeyCode.RightArrow;
    KeyCode back = KeyCode.DownArrow;


    [SerializeField]
    private float torque;
    [SerializeField]
    private float speed;


    private Rigidbody2D rb2d;
	private Renderer rend;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);

		pos.x = Mathf.Clamp(pos.x, 0, Screen.width - rend.bounds.size.x);
		pos.y = Mathf.Clamp(pos.y, 0, Screen.height - rend.bounds.size.y);

		transform.position = Camera.main.ScreenToWorldPoint(pos);

		// It would also be possible to change the transform, instead of using physics/rigidbody:
	
		// Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
    	// pos.x = Mathf.Clamp01(pos.x);
		// pos.y = Mathf.Clamp01(pos.y);
    	// transform.position = Camera.main.ViewportToWorldPoint(pos);
        // Vector2 position = transform.position;
        // position.x = position.x + 0.1f * horizontal * Time.deltaTime;
        // position.y = position.y + 0.1f * vertical * Time.deltaTime;
        // transform.position = position;
    }

    void FixedUpdate()
    {
		// Sustained input, so should be okay. See https://www.reddit.com/r/Unity3D/comments/7267yi/player_inputs_update_or_fixedupdate/
        float turn = Input.GetAxis("Horizontal");
        float thrust = Input.GetAxis("Vertical");

        rb2d.AddTorque(turn * torque * Time.deltaTime);
		rb2d.AddForce(transform.up * thrust * speed * Time.deltaTime);
    }
}
