using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBall : MonoBehaviour
{
	enum eMode
	{
		NONE,
		VELOCITY,
		ADD_FORCE,
		ADD_TORQUE
	}

	eMode mode;
	Vector3 start;

	Rigidbody body;

	void Start()
	{
		mode = eMode.NONE;
		start = transform.position;

		body = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Debug.Log("속력 바꾸기");
			mode = eMode.VELOCITY;
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Debug.Log("힘을 가하기");
			mode = eMode.ADD_FORCE;
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			Debug.Log("회전력을 가하기");
			mode = eMode.ADD_TORQUE;
		}
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			mode = eMode.NONE;
			transform.position = start;

			body.velocity = Vector3.zero;
			body.angularVelocity = Vector3.zero;
		}

		switch (mode)
		{
			case eMode.VELOCITY:
				body.velocity = 100 * Time.deltaTime * new Vector3(
					Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
				break;

			case eMode.ADD_FORCE:
				if (Input.GetButtonDown("Jump"))
					body.AddForce(20000 * Time.deltaTime * Vector3.up, ForceMode.Impulse);
				Vector3 force = new Vector3(
					Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
				body.AddForce(1000 * Time.deltaTime * force, ForceMode.Impulse);
				break;

			case eMode.ADD_TORQUE:
				Vector3 torque = 10000 * Time.deltaTime * Vector3.up;
				body.AddTorque(torque);
				break;
		}
	}
}
