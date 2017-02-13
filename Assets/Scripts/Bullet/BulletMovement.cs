using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
	public float speed = 5f;
	[SerializeField] private Rigidbody2D _rigid;
	[SerializeField] private Vector2 direction;

	void OnEnable ()
	{
		if (!_rigid)
			_rigid = GetComponent<Rigidbody2D> ();

		GetDirection ();
		_rigid.AddForce (speed * direction);
	}

	private void GetDirection ()
	{
		float angle = transform.rotation.eulerAngles.z;
		direction.x = Mathf.Cos ((angle + 90) * Mathf.Deg2Rad);
		direction.y = Mathf.Sin ((angle + 90) * Mathf.Deg2Rad);

//		direction.Normalize ();
	}
}
