using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectInfoManager : MonoBehaviour
{
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
}
