using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
	Rigidbody body;

	bool isJump = false;
	public float jumpPower = 30;

	void Awake()
	{
		body = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.GetButtonDown("Jump") && isJump == false)
		{
			body.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
			isJump = true;
		}
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		body.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Floor")
		{
			isJump = false;
		}
	}
}
