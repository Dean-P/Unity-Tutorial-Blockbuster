# Unity3D Tutorial - BlockBuster

The tutorial comes from the book from Packt publishing, which you are encouraged to buy and use for learning.


# Build a Scene

1. Create a new scene in Unity
    - File > New Scene
    
2. Create a `Plane` object to act as ground
    - GameObjects > 3D Objects > Plane
    - You may need to change the position and scale of the plane
    
3. Click-and-drag the `Row` prefab into the scene to create a row of bricks
    - Repeat many times to add more rows
    
5. Move the rows around to build some structure


# Attach Scripts

Scripts are found in `Assets/Mine/Scripts`
Prefab objects are found in `Assets/Mine/Prefabs`

1. Attach script for camera controls `CameraMovement.cs` to `MainCamera`
    - You will need to set the value of `speed` to something above 0
    
2. Attach script for shooting `ShootBullet.cs` to `MainCamera`
    - You will need to set the value of `projectile` to the Bullet **prefab (in the Prefabs folder)**
    
3. Attach script for the bullet `BulletExplode.cs` to `Bullet` **prefab**
    - You will need to set the value of `explosion` to the `Explosion` **prefab (in the Prefabs folder)**
    
4. Attach script for the explosion and bullet `DestroyByTime.cs` to `Explosion` **prefab** & `Bullet` **prefab**
    - You will need to set the value of `lifetime` to something above 0

Once these are setup and your scene is made, click run.

# Controls
| Input             | Action          |
|-------------------|-----------------|
| Arrow Keys        | Move the camera |
| Left Mouse Button | Fire a bullet   |


# Console Errors

**Nothing shooting when mouse is clicked**

Check the `console` window, there may be an error there. Something like this:

>UnassignedReferenceException: The variable projectile of ShootBullet has not been assigned.

This means the `ShootBullet` script is not setup properly. The script's projectile needs to be set to the `Bullet` **prefab** in the Prefabs folder. Click-and-drag the Bullet prefab from the assets folder into the `projectile` field in the `ShootBullet` script in the `Inspector` Window.

If there is no error, check the `Bullet` Prefab. The `DestroyByTime` script may not be setup correctly. The value of `lifetime` needs to be above 0 or the bullet will disappear immediately.


# Extra Information

## In-Depth Tutorial
PDF Tutorial on how to create this game can be found here [https://github.com/Dean-P/Unity-Tutorial-BlockBuster/blob/master/Tutorial-Chapter2.zip](https://github.com/Dean-P/Unity-Tutorial-BlockBuster/blob/master/Tutorial-Chapter2.zip). 

## Scripts

`CameraMovement.cs`
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

`ShootBullet.cs`
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

`BulletExplode.cs`
```csharp
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
```

`DestroyByTime.cs`
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



