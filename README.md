# Unity3D Tutorial - BlockBuster

PDF Tutorial on how to create this game can be found here [https://github.com/Dean-P/Unity-Tutorial-BlockBuster/blob/master/Tutorial-Chapter2.zip](https://github.com/Dean-P/Unity-Tutorial-BlockBuster/blob/master/Tutorial-Chapter2.zip). 

The tutorial comes from the book from Packt publishing, which you are encouraged to buy and use for learning.

Script for camera controls (attach to `MainCamera`)

```csharp
using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public float speed = 1;

	// Update is called once per frame
	void Update () {
		// read key and move according to direction given in the movement vector
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
			transform.Translate(new Vector3(0f, 0.01 * speed, 0f));
		} else if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
			// don't let camera move under ground
			if (transform.position.y > 0.5) {
				transform.Translate(new Vector3(0f, -0.01 * speed, 0f));
			}
		} else if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			transform.Translate(new Vector3(-0.01 * speed, 0f, 0f));
		} else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			transform.Translate(new Vector3(0.01 * speed, 0f, 0f));
		}
	}
}
```

Script for shooting (Attach to `MainCamera`):

```csharp
using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour {
	
	public GameObject bullet;
	public float speed = 30f;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			var go = Instantiate(bullet, this.transform.position, Quaternion.identity) as GameObject;
			var instance = go.GetComponent<Rigidbody>();
			instance.velocity = transform.forward * speed;
		}
	
	}
}	
```

Script for the bullet (Attach to `Bullet`)

```csharp
using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
	public float lifetime;

	void Start ()
	{
		Destroy (gameObject, lifetime);
	}
}
```



