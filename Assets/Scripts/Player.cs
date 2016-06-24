using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Linq;
using System.Text;

public class Player : MonoBehaviour {

	public string jump = "space";

	bool isFalling = false;
	Rigidbody rigidbody;
	Animator animator;

	bool isDead = false;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody.IsSleeping()) {
			rigidbody.WakeUp();
		}

		if (!isFalling) {
			animator.SetBool ("Jumping", false);
		}

		if (Input.GetKey (jump) && !isFalling) {
			rigidbody.velocity = new Vector3(0, 6, 0);
			animator.SetBool ("Jumping", true);
		}

		isFalling = true;
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.gameObject.tag == "car") {
			rigidbody.gameObject.SetActive (false);
			GetComponent<MeshRenderer> ().gameObject.SetActive (false);
			isDead = true;
		}
	}

	void OnCollisionStay(Collision collisionInfo) {
		isFalling = false;
	}

	public bool isAlive() {
		return !isDead;
	}
}
