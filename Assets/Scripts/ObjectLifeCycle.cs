using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ObjectLifeCycle : MonoBehaviour
{
	void Awake()
	{
		string name = MethodBase.GetCurrentMethod().Name;
		Debug.Log(name + ": 게임 오브젝트가 생성될 때 실행");
	}

	void OnEnable()
	{
		string name = MethodBase.GetCurrentMethod().Name;
		Debug.Log(name + ": 게임 오브젝트가 활성화 되었을 때 실행");
	}

	void Start()
	{
		string name = MethodBase.GetCurrentMethod().Name;
		Debug.Log(name + ": 업데이트 시작 직전에 실행");
	}

	void FixedUpdate()
	{
		string name = MethodBase.GetCurrentMethod().Name;
		Debug.Log(name + ": 물리 연산 업데이트, 고정된 주기로 CPU를 많이 사용");
	}

	void Update()
	{
		string name = MethodBase.GetCurrentMethod().Name;
		Debug.Log(name + ": 게임 로직 업데이트, 환경에 따라 실행주기가 떨어질 수 있음");
	}

	void LateUpdate()
	{
		string name = MethodBase.GetCurrentMethod().Name;
		Debug.Log(name + ": 모든 업데이트가 끝난 후 실행");
	}

	void OnDisable()
	{
		string name = MethodBase.GetCurrentMethod().Name;
		Debug.Log(name + ": 게임 오브젝트가 비활성화 되었을 때 실행");
	}

	void OnDestroy()
	{
		string name = MethodBase.GetCurrentMethod().Name;
		Debug.Log(name + ": 게임 오브젝트가 삭제될 때 실행");
	}
}
