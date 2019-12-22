using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBall : MonoBehaviour
{
	MeshRenderer mesh;
	Material material;

	void Start()
	{
		mesh = GetComponent<MeshRenderer>();
		material = mesh.material;
	}

	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log("물리적 충돌이 시작할 때 호출되는 함수");

		if (collision.gameObject.name == "MyBall")
		{
			material.color = new Color(0, 0, 0);
		}
	}

	private void OnCollisionStay(Collision collision)
	{
		Debug.Log("물리적 충돌이 유지되는 동안 호출되는 함수");
	}

	private void OnCollisionExit(Collision collision)
	{
		Debug.Log("물리적 충돌이 끝났을 때 호출되는 함수");

		if (collision.gameObject.name == "MyBall")
		{
			material.color = new Color(0, 0, 0);
		}
	}

}
