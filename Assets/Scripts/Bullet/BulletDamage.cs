using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
	public int damage = 50;

	void OnTriggerEnter2D (Collider2D hit)
	{
		if (hit.CompareTag ("Player")) {
			hit.GetComponent<Player> ().TakeDamage (damage);
		} 
		DestroyByhit ();
	}

	void DestroyByhit ()
	{
		transform.GetChild (0).gameObject.SetActive (true);
		transform.DetachChildren ();
		Destroy (gameObject);
	}
}
