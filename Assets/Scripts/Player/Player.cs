using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int heath;
	public float speed = 5f;

	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;

	[SerializeField] private Transform _trans;
	[SerializeField] private Rigidbody2D _rigid;
	private Vector2 direction;

	public List<Transform> bots;

	void Start ()
	{
		FindAllBot ();
	}

	void Update ()
	{
		direction = Vector2.zero;

		if (Input.GetKey (up))
			MoveUp ();
		if (Input.GetKey (down))
			MoveDown ();

		
		if (Input.GetKey (left))
			MoveLeft ();
		if (Input.GetKey (right))
			MoveRight ();

		MoveByAddVelocity ();
	}

	#region Move

	public void MoveUp ()
	{
		direction.y += 1;
	}

	public void MoveDown ()
	{
		direction.y += -1;
	}

	public void MoveLeft ()
	{
		direction.x += -1;
	}

	private void MoveRight ()
	{
		direction.x += 1;
	}

	public void MoveByAddVelocity ()
	{
		_rigid.velocity = direction * speed;

		if (direction != Vector2.zero) {
			float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg - 90;
			_trans.rotation = Quaternion.Euler (0, 0, angle);
		}
	}

	#endregion

	public void FindAllBot ()
	{
		GameObject[] botObject = GameObject.FindGameObjectsWithTag ("Player");
		bots = new List<Transform> ();

		foreach (GameObject bo in botObject)
			if (bo != gameObject)
				bots.Add (bo.transform);
	}

	public void TakeDamage (int damage)
	{
		heath -= damage;

		if (heath <= 0) {
			Destroy (gameObject);
		}
	}

}
