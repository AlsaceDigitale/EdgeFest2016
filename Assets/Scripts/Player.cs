using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Linq;
using System.Text;

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

		if (Input.GetKey (KeyCode.Joystick1Button14) && !isFalling) {
			rigidbody.velocity = new Vector3(0, 7, 0);
		}

		isFalling = true;


		for (int j = 1; j < 10; j++) {
			for (int i = 0; i < 20; i++) {
				if (Input.GetKeyDown ("joystick " + j + " button " + i)) {
					Debug.Log ("joystick " + j + " button " + i);
				}
			}
		}
		if (Input.anyKey) {
//			Debug.Log (Input.inputString);
		}

		Debug.Log ("Joystick names: " + string.Join(",", Input.GetJoystickNames ()));
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.gameObject.tag == "car") {
			rigidbody.gameObject.SetActive (false);
			GetComponent<MeshRenderer> ().gameObject.SetActive (false);
		}
	}

	void OnCollisionStay(Collision collisionInfo) {
		isFalling = false;
	}
}
