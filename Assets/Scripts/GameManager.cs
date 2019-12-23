using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public int totalItemCount;
	public int stage;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Restart this stage: " + stage);
			SceneManager.LoadScene(stage);
		}
	}
}
