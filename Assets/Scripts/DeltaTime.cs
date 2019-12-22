using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaTime : MonoBehaviour
{
	void Start()
	{
		Debug.Log("Time.deltaTime 사용하는 방법");
		Debug.Log("Time.deltaTime : 이전 프레임의 완료까지 걸린 시간");
		Debug.Log("deltaTime 값은 프레임이 적으면 크고, 프레임이 많으면 작음");
	}
	void Update()
	{
		Debug.Log("Translate() : 벡터에 곱하기");
		Debug.Log("transform.Translate(Vec * Time.deltaTime);");

		Vector3 vec = new Vector3(
			Input.GetAxisRaw("Horizontal"),
			Input.GetAxisRaw("Vertical"), 0);
		transform.Translate(vec * Time.deltaTime);

		Debug.Log("Vector 함수 : 시간 매개변수에 곱하기");
		Debug.Log("Vector3.Lerp(Vec1, Vec2, T * Time.deltaTime);");

		Vector3 current = transform.position;
		Vector3 target = Vector3.forward;
		float t = 0.05f;
		transform.position = Vector3.Lerp(current, target, t * Time.deltaTime);
	}
}
