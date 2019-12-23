using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
			manager.GetItem(itemCount);
			audio.Play();
			other.gameObject.SetActive(false);
		}
		else if (other.tag == "Finish")
		{
			if (itemCount == manager.totalItemCount)
			{
				if (manager.stage == 2)
				{
					Debug.Log("Finish all stage!");
					SceneManager.LoadScene(0);
				}
				else
				{
					Debug.Log("Go to next stage: " + (manager.stage + 1));
					SceneManager.LoadScene(manager.stage + 1);
				}

			}
			else
			{
				Debug.Log("Restart this stage: " + manager.stage);
				SceneManager.LoadScene(manager.stage);
			}
		}
	}
}
