using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	bool isFalling = false;
	Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody.IsSleeping()) {
			rigidbody.WakeUp();
		}

		if (Input.GetKey (KeyCode.Space) && !isFalling) {
			rigidbody.velocity = new Vector3(0, 7, 0);
		}

		isFalling = true;
	}

	void OnCollisionStay(Collision collisionInfo) {
		isFalling = false;
	}
}
