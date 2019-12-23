using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public int totalItemCount;
	public int stage;
	public Text playerItemCountText;
	public Text stageItemCountText;

	void Awake()
	{
		stageItemCountText.text = "/ " + totalItemCount;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Restart this stage: " + stage);
			SceneManager.LoadScene(stage);
		}
	}

	public void GetItem(int count)
	{
		playerItemCountText.text = count.ToString();
	}
}
