using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerRotateGunBarrel : MonoBehaviour
{
	public event Action all;

	[SerializeField] private Player player;

	[SerializeField] private Transform _trans;

	void OnEnable ()
	{
		all += FillTargetCanFind;
		all += RotateToTarget;
	}

	void OnDisable ()
	{
		all -= RotateToTarget;
		all -= FillTargetCanFind;
	}

	void Update ()
	{
		if (all != null)
			all.Invoke ();

//		FillTargetCanFind ();
//
//		RotateToTarget ();
	}

	public void RotateBarrels (bool isRight, float speed)
	{
		_trans.Rotate (0, 0, speed * (isRight ? -1 : 1));
	}

	private void FillTargetCanFind ()
	{
		if (player.bots.Count > 0)
			while (player.bots.Count > 0 && !player.bots [0])
				player.bots.RemoveAt (0);
	}

	private void RotateToTarget ()
	{
		if (player.bots.Count > 0)
			RotateToTarget (player.bots [0]);
	}

	private void RotateToTarget (Transform target)
	{
		Vector2 getDir = target.position - _trans.position;
		float angle = Mathf.Atan2 (getDir.y, getDir.x) * Mathf.Rad2Deg - 90;
		_trans.rotation = Quaternion.Euler (0, 0, angle);
	}
}
