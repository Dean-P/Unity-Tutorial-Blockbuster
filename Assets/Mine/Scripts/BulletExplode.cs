using UnityEngine;
using System.Collections;

public class BulletExplode : MonoBehaviour {

	public GameObject explosion;

	// detects collision with the box, destroys bullet and creates explosion
	void OnCollisionEnter(Collision other) {
		print ("Collideed");
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
	}


}
