using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour {

	public float speed = 30;
	public Rigidbody projectile;

	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			Rigidbody clone;
			clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(Vector3.forward * speed);
		}
	}
}	