using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public float speed = 1;

	// Update is called once per frame
	void Update () {
		// read key and move according to direction given in the movement vector
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate(new Vector3(0f, Time.deltaTime * speed, 0f));
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			// don't let camera move under ground
			if (transform.position.y > 0.5) {
				transform.Translate(new Vector3(0f, -Time.deltaTime * speed, 0f));
			}
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate(new Vector3(-Time.deltaTime * speed, 0f, 0f));
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate(new Vector3(Time.deltaTime * speed, 0f, 0f));
		}
	}
}
