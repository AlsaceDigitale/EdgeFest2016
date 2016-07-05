﻿using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Linq;
using System.Text;

public class Player : MonoBehaviour {

	public string jump = "space";
	public string jump2 = "space";

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

		var input = KeyCode.JoystickButton1;
		if (jump == "Joystick1Button1")
			input = KeyCode.Joystick1Button1;
		else if (jump == "Joystick1Button2")
			input = KeyCode.Joystick1Button2;
		else if (jump == "Joystick1Button3")
			input = KeyCode.Joystick1Button3;
		else if (jump == "Joystick1Button4")
			input = KeyCode.Joystick1Button4;
		else if (jump == "Joystick1Button5")
			input = KeyCode.Joystick1Button5;
		else if (jump == "Joystick1Button6")
			input = KeyCode.Joystick1Button6;
		else if (jump == "Joystick1Button7")
			input = KeyCode.Joystick1Button7;
		else if (jump == "Joystick1Button8")
			input = KeyCode.Joystick1Button8;
		else if (jump == "Joystick1Button9")
			input = KeyCode.Joystick1Button9;
		else if (jump == "Joystick1Button10")
			input = KeyCode.Joystick1Button10;
		else if (jump == "Joystick1Button11")
			input = KeyCode.Joystick1Button11;
		else if (jump == "Joystick1Button12")
			input = KeyCode.Joystick1Button12;
		else if (jump == "Joystick1Button13")
			input = KeyCode.Joystick1Button13;
		else if (jump == "Joystick1Button14")
			input = KeyCode.Joystick1Button14;
		else if (jump == "Joystick1Button15")
			input = KeyCode.Joystick1Button15;
		else if (jump == "Joystick1Button16")
			input = KeyCode.Joystick1Button16;
		else if (jump == "Joystick1Button17")
			input = KeyCode.Joystick1Button17;
		else if (jump == "Joystick1Button18")
			input = KeyCode.Joystick1Button18;
		else if (jump == "Joystick1Button19")
			input = KeyCode.Joystick1Button19;
		else if (jump == "Joystick2Button1")
			input = KeyCode.Joystick2Button1;
		else if (jump == "Joystick2Button2")
			input = KeyCode.Joystick2Button2;
		else if (jump == "Joystick2Button3")
			input = KeyCode.Joystick2Button3;
		else if (jump == "Joystick2Button4")
			input = KeyCode.Joystick2Button4;
		else if (jump == "Joystick2Button5")
			input = KeyCode.Joystick2Button5;
		else if (jump == "Joystick2Button6")
			input = KeyCode.Joystick2Button6;
		else if (jump == "Joystick2Button7")
			input = KeyCode.Joystick2Button7;
		else if (jump == "Joystick2Button8")
			input = KeyCode.Joystick2Button8;
		else if (jump == "Joystick2Button9")
			input = KeyCode.Joystick2Button9;
		else if (jump == "Joystick2Button10")
			input = KeyCode.Joystick2Button10;
		else if (jump == "Joystick2Button11")
			input = KeyCode.Joystick2Button11;
		else if (jump == "Joystick2Button12")
			input = KeyCode.Joystick2Button12;
		else if (jump == "Joystick2Button13")
			input = KeyCode.Joystick2Button13;
		else if (jump == "Joystick2Button14")
			input = KeyCode.Joystick2Button14;
		else if (jump == "Joystick2Button15")
			input = KeyCode.Joystick2Button15;
		else if (jump == "Joystick2Button16")
			input = KeyCode.Joystick2Button16;
		else if (jump == "Joystick2Button17")
			input = KeyCode.Joystick2Button17;
		else if (jump == "Joystick2Button18")
			input = KeyCode.Joystick2Button18;
		else if (jump == "Joystick2Button19")
			input = KeyCode.Joystick2Button19;

		var input2 = KeyCode.JoystickButton1;
		if (jump == "Joystick1Button1")
			input2 = KeyCode.Joystick1Button1;
		else if (jump == "Joystick1Button2")
			input2 = KeyCode.Joystick1Button2;
		else if (jump == "Joystick1Button3")
			input2 = KeyCode.Joystick1Button3;
		else if (jump == "Joystick1Button4")
			input2 = KeyCode.Joystick1Button4;
		else if (jump == "Joystick1Button5")
			input2 = KeyCode.Joystick1Button5;
		else if (jump == "Joystick1Button6")
			input2 = KeyCode.Joystick1Button6;
		else if (jump == "Joystick1Button7")
			input2 = KeyCode.Joystick1Button7;
		else if (jump == "Joystick1Button8")
			input2 = KeyCode.Joystick1Button8;
		else if (jump == "Joystick1Button9")
			input2 = KeyCode.Joystick1Button9;
		else if (jump == "Joystick1Button10")
			input2 = KeyCode.Joystick1Button10;
		else if (jump == "Joystick1Button11")
			input2 = KeyCode.Joystick1Button11;
		else if (jump == "Joystick1Button12")
			input2 = KeyCode.Joystick1Button12;
		else if (jump == "Joystick1Button13")
			input2 = KeyCode.Joystick1Button13;
		else if (jump == "Joystick1Button14")
			input2 = KeyCode.Joystick1Button14;
		else if (jump == "Joystick1Button15")
			input2 = KeyCode.Joystick1Button15;
		else if (jump == "Joystick1Button16")
			input2 = KeyCode.Joystick1Button16;
		else if (jump == "Joystick1Button17")
			input2 = KeyCode.Joystick1Button17;
		else if (jump == "Joystick1Button18")
			input2 = KeyCode.Joystick1Button18;
		else if (jump == "Joystick1Button19")
			input2 = KeyCode.Joystick1Button19;
		else if (jump == "Joystick2Button1")
			input2 = KeyCode.Joystick2Button1;
		else if (jump == "Joystick2Button2")
			input2 = KeyCode.Joystick2Button2;
		else if (jump == "Joystick2Button3")
			input2 = KeyCode.Joystick2Button3;
		else if (jump == "Joystick2Button4")
			input2 = KeyCode.Joystick2Button4;
		else if (jump == "Joystick2Button5")
			input2 = KeyCode.Joystick2Button5;
		else if (jump == "Joystick2Button6")
			input2 = KeyCode.Joystick2Button6;
		else if (jump == "Joystick2Button7")
			input2 = KeyCode.Joystick2Button7;
		else if (jump == "Joystick2Button8")
			input2 = KeyCode.Joystick2Button8;
		else if (jump == "Joystick2Button9")
			input2 = KeyCode.Joystick2Button9;
		else if (jump == "Joystick2Button10")
			input2 = KeyCode.Joystick2Button10;
		else if (jump == "Joystick2Button11")
			input2 = KeyCode.Joystick2Button11;
		else if (jump == "Joystick2Button12")
			input2 = KeyCode.Joystick2Button12;
		else if (jump == "Joystick2Button13")
			input2 = KeyCode.Joystick2Button13;
		else if (jump == "Joystick2Button14")
			input2 = KeyCode.Joystick2Button14;
		else if (jump == "Joystick2Button15")
			input2 = KeyCode.Joystick2Button15;
		else if (jump == "Joystick2Button16")
			input2 = KeyCode.Joystick2Button16;
		else if (jump == "Joystick2Button17")
			input2 = KeyCode.Joystick2Button17;
		else if (jump == "Joystick2Button18")
			input2 = KeyCode.Joystick2Button18;
		else if (jump == "Joystick2Button19")
			input2 = KeyCode.Joystick2Button19;

		if ((!Input.GetKey (input) && !Input.GetKey (input2)) && !isFalling) {
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
