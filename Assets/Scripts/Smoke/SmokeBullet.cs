using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBullet : MonoBehaviour
{
	public float timeDestroy = .5f;

	void OnEnable ()
	{
		Destroy (gameObject, timeDestroy);
	}

}
