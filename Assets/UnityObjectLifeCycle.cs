using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityObjectLifeCycle : MonoBehaviour
{
	void Awake()
	{
		Debug.Log("Invoked once when creating a game object.");
	}

	void OnEnable()
	{
		Debug.Log("Invoked when the game object is activated.");
	}

	void Start()
	{
		Debug.Log("Invoked just before updating the game object.");
	}

	void FixedUpdate()
	{
		Debug.Log("Update physics for fixed framerate.");
	}

	void Update()
	{
		Debug.Log("Update game logics.");
	}

	void LateUpdate()
	{
		Debug.Log("Invoked after Update().");
	}

	void OnDisable()
	{
		Debug.Log("Invoked when the game object is deactivated.");
	}

	void OnDestroy()
	{
		Debug.Log("Invoked when deleting the game object.");
	}
}
