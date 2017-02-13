using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
	public GameObject bullet;
	public Transform[] barrels;
	public float rate = 1f;
	public KeyCode fireKey;

	private float timer;

	void Start ()
	{
		timer = 0;
	}

	void Update ()
	{
		if (timer + 1 / rate < Time.time && Input.GetKeyDown (fireKey))
			Fire ();
	}

	public void Fire ()
	{
		foreach (Transform barrel in barrels) {
			Instantiate (bullet, barrel.position, barrel.rotation);
		}
		timer = Time.time;
	}

}
