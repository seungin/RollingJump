using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
	enum eMode
	{
		NONE,
		MOVE_TOWARDS,
		SMOOTH_DAMP,
		LERP,
		SLERP
	}

	eMode mode;
	Vector3 start;
	Vector3 target;
	Vector3 current;
	Vector3 next;

	public float maxDistanceDelta = 0.2f;
	public float smoothTime = 0.1f;
	public float t = 0.05f;

	void Start()
	{
		mode = eMode.NONE;
		start = transform.position;
		target = new Vector3(8, 1.5f, 0);
	}

	void Update()
	{
		if (Input.anyKeyDown)
		{
			mode = eMode.NONE;
			transform.position = start;
		}

		if (Input.GetKeyDown(KeyCode.Alpha1))
			mode = eMode.MOVE_TOWARDS;

		if (Input.GetKeyDown(KeyCode.Alpha2))
			mode = eMode.SMOOTH_DAMP;

		if (Input.GetKeyDown(KeyCode.Alpha3))
			mode = eMode.LERP;

		if (Input.GetKeyDown(KeyCode.Alpha4))
			mode = eMode.SLERP;

		current = transform.position;

		switch (mode)
		{
			case eMode.MOVE_TOWARDS:
				next = Vector3.MoveTowards(current, target, maxDistanceDelta);
				Debug.Log("등속 이동, maxDistanceDelta에 비례하여 속도 증가");
				break;

			case eMode.SMOOTH_DAMP:
				Vector3 currentVelocity = Vector3.zero;  
				next = Vector3.SmoothDamp(current, target, ref currentVelocity, smoothTime);
				Debug.Log("부드러운 감속 이동, SmoothTime에 반비례하여 속도 증가");
				break;

			case eMode.LERP:
				next = Vector3.Lerp(current, target, t);
				Debug.Log("선형 보간 이동, t에 비례하여 속도 증가 (최대값 1)");
				Debug.Log("SmoothDamp보다 감속시간이 김");
				break;

			case eMode.SLERP:
				next = Vector3.Slerp(current, target, t);
				Debug.Log("구면 선형 보간 이동, 호를 그리며 이동");
				break;

			default:
				next = current;
				break;
		}

		transform.position = next;
	}
}
