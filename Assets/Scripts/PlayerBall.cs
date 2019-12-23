using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
	Rigidbody body;
	AudioSource audio;

	public float jumpPower;
	public int itemCount;
	public GameManager manager;

	bool isJump = false;

	void Awake()
	{
		body = GetComponent<Rigidbody>();
		audio = GetComponent<AudioSource>();
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
		if (collision.gameObject.tag == "Floor")
		{
			isJump = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Item")
		{
			itemCount++;
			audio.Play();
			other.gameObject.SetActive(false);
		}
		else if (other.tag == "Finish")
		{
			if (itemCount == manager.totalItemCount)
			{
				Debug.Log("Game Clear!");
			}
			else
			{
				Debug.Log("Restart..");
			}
		}
	}
}
