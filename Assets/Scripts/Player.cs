using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.IO.Ports;

public class Player : MonoBehaviour {

	public string jump = "space";
	public string jump2 = "space";
	public string jump3 = "space";
	private bool activatePump = false;

	public string team = "1";

	public GameObject gameController;

	bool isFalling = false;
	bool canJump = false;
	Rigidbody rigidbody;
	Animator animator;

	bool isDead = false;
	static SerialPort stream = null;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find("/GameController");

		activatePump = gameController.GetComponent<GameController>().IsPumpActivated();

		if (stream == null && activatePump) {
			try {
				stream = new SerialPort("/dev/ttyACM0", 9600, Parity.None, 8, StopBits.One);
				stream.Open();
			} catch {
				Debug.LogError("Error when initializing serial port.");
			}
		}

		rigidbody = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();

		// Debug.Log(string.Join(",",Input.GetJoystickNames()));

		// var input = getKeyCodeFromCharCode(jump);
		// var input2 = getKeyCodeFromCharCode(jump2);

		// if (!Input.GetKey (input) && !Input.GetKey (input2)) {
		// 	rigidbody.gameObject.SetActive (false);
		// 	GetComponent<MeshRenderer> ().gameObject.SetActive (false);
		// 	isDead = true;
		// }
	}
	
	public bool PlayerIsPresent() {
		var input = getKeyCodeFromCharCode(jump);
		var input2 = getKeyCodeFromCharCode(jump2);

		if (Input.GetKey(input) || Input.GetKey(input2)) {
			return true;
		}

		return false;
	}

	// Update is called once per frame
	void Update () {
		if (rigidbody.IsSleeping()) {
			rigidbody.WakeUp();
		}

		if (!isFalling) {
			animator.SetBool ("Jumping", false);
		}

		var input = getKeyCodeFromCharCode(jump);
		var input2 = getKeyCodeFromCharCode(jump2);
		var input3 = getKeyCodeFromCharCode(jump3);

		if (Input.GetKey (input) || Input.GetKey (input2) || Input.GetKey (input3)) {
			canJump = true;
		}

		if ((!Input.GetKey (input) && !Input.GetKey (input2) && !Input.GetKey (input3)) && !isFalling && canJump) {
			rigidbody.velocity = new Vector3(0, 6, 0);
			animator.SetBool ("Jumping", true);
			canJump = false;
		}

		isFalling = true;


		// if (Input.GetKey(KeyCode.Joystick1Button1))
		// 	Debug.Log("KeyCode.Joystick1Button1");
		// if (Input.GetKey(KeyCode.Joystick1Button2))
		// 	Debug.Log("KeyCode.Joystick1Button2");
		// if (Input.GetKey(KeyCode.Joystick1Button3))
		// 	Debug.Log("KeyCode.Joystick1Button3");
		// if (Input.GetKey(KeyCode.Joystick1Button4))
		// 	Debug.Log("KeyCode.Joystick1Button4");
		// if (Input.GetKey(KeyCode.Joystick1Button5))
		// 	Debug.Log("KeyCode.Joystick1Button5");
		// if (Input.GetKey(KeyCode.Joystick1Button6))
		// 	Debug.Log("KeyCode.Joystick1Button6");
		// if (Input.GetKey(KeyCode.Joystick1Button7))
		// 	Debug.Log("KeyCode.Joystick1Button7");
		// if (Input.GetKey(KeyCode.Joystick1Button8))
		// 	Debug.Log("KeyCode.Joystick1Button8");
		// if (Input.GetKey(KeyCode.Joystick1Button9))
		// 	Debug.Log("KeyCode.Joystick1Button9");
		// if (Input.GetKey(KeyCode.Joystick1Button10))
		// 	Debug.Log("KeyCode.Joystick1Button10");
		// if (Input.GetKey(KeyCode.Joystick1Button11))
		// 	Debug.Log("KeyCode.Joystick1Button11");
		// if (Input.GetKey(KeyCode.Joystick1Button12))
		// 	Debug.Log("KeyCode.Joystick1Button12");
		// if (Input.GetKey(KeyCode.Joystick1Button13))
		// 	Debug.Log("KeyCode.Joystick1Button13");
		// if (Input.GetKey(KeyCode.Joystick1Button14))
		// 	Debug.Log("KeyCode.Joystick1Button14");
		// if (Input.GetKey(KeyCode.Joystick1Button15))
		// 	Debug.Log("KeyCode.Joystick1Button15");
		// if (Input.GetKey(KeyCode.Joystick1Button16))
		// 	Debug.Log("KeyCode.Joystick1Button16");
		// if (Input.GetKey(KeyCode.Joystick1Button17))
		// 	Debug.Log("KeyCode.Joystick1Button17");
		// if (Input.GetKey(KeyCode.Joystick1Button18))
		// 	Debug.Log("KeyCode.Joystick1Button18");
		// if (Input.GetKey(KeyCode.Joystick1Button19))
		// 	Debug.Log("KeyCode.Joystick1Button19");

		// if (Input.GetKey(KeyCode.Joystick2Button1))
		// 	Debug.Log("KeyCode.Joystick2Button1");
		// if (Input.GetKey(KeyCode.Joystick2Button2))
		// 	Debug.Log("KeyCode.Joystick2Button2");
		// if (Input.GetKey(KeyCode.Joystick2Button3))
		// 	Debug.Log("KeyCode.Joystick2Button3");
		// if (Input.GetKey(KeyCode.Joystick2Button4))
		// 	Debug.Log("KeyCode.Joystick2Button4");
		// if (Input.GetKey(KeyCode.Joystick2Button5))
		// 	Debug.Log("KeyCode.Joystick2Button5");
		// if (Input.GetKey(KeyCode.Joystick2Button6))
		// 	Debug.Log("KeyCode.Joystick2Button6");
		// if (Input.GetKey(KeyCode.Joystick2Button7))
		// 	Debug.Log("KeyCode.Joystick2Button7");
		// if (Input.GetKey(KeyCode.Joystick2Button8))
		// 	Debug.Log("KeyCode.Joystick2Button8");
		// if (Input.GetKey(KeyCode.Joystick2Button9))
		// 	Debug.Log("KeyCode.Joystick2Button9");
		// if (Input.GetKey(KeyCode.Joystick2Button10))
		// 	Debug.Log("KeyCode.Joystick2Button10");
		// if (Input.GetKey(KeyCode.Joystick2Button11))
		// 	Debug.Log("KeyCode.Joystick2Button11");
		// if (Input.GetKey(KeyCode.Joystick2Button12))
		// 	Debug.Log("KeyCode.Joystick2Button12");
		// if (Input.GetKey(KeyCode.Joystick2Button13))
		// 	Debug.Log("KeyCode.Joystick2Button13");
		// if (Input.GetKey(KeyCode.Joystick2Button14))
		// 	Debug.Log("KeyCode.Joystick2Button14");
		// if (Input.GetKey(KeyCode.Joystick2Button15))
		// 	Debug.Log("KeyCode.Joystick2Button15");
		// if (Input.GetKey(KeyCode.Joystick2Button16))
		// 	Debug.Log("KeyCode.Joystick2Button16");
		// if (Input.GetKey(KeyCode.Joystick2Button17))
		// 	Debug.Log("KeyCode.Joystick2Button17");
		// if (Input.GetKey(KeyCode.Joystick2Button18))
		// 	Debug.Log("KeyCode.Joystick2Button18");
		// if (Input.GetKey(KeyCode.Joystick2Button19))
		// 	Debug.Log("KeyCode.Joystick2Button19");

	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.gameObject.tag == "car") {
			if (activatePump) {
				try {
					stream.Write("p:" + team + "\r\n");
				} catch {
					Debug.LogError ("Port not open.");
				}
			}
			// gameController.GetComponent<GameController>().SetText("Player die");
			isDead = true;
			rigidbody.gameObject.SetActive (false);
			GetComponent<MeshRenderer> ().gameObject.SetActive (false);
		}
	}

	void OnCollisionStay(Collision collisionInfo) {
		isFalling = false;
	}

	public bool isAlive() {
		return !isDead;
	}

	private static KeyCode getKeyCodeFromCharCode(string charCode) {
		var input = KeyCode.Space;

		if (charCode == "Joystick1Button1")
			input = KeyCode.Joystick1Button1;
		else if (charCode == "Joystick1Button2")
			input = KeyCode.Joystick1Button2;
		else if (charCode == "Joystick1Button3")
			input = KeyCode.Joystick1Button3;
		else if (charCode == "Joystick1Button4")
			input = KeyCode.Joystick1Button4;
		else if (charCode == "Joystick1Button5")
			input = KeyCode.Joystick1Button5;
		else if (charCode == "Joystick1Button6")
			input = KeyCode.Joystick1Button6;
		else if (charCode == "Joystick1Button7")
			input = KeyCode.Joystick1Button7;
		else if (charCode == "Joystick1Button8")
			input = KeyCode.Joystick1Button8;
		else if (charCode == "Joystick1Button9")
			input = KeyCode.Joystick1Button9;
		else if (charCode == "Joystick1Button10")
			input = KeyCode.Joystick1Button10;
		else if (charCode == "Joystick1Button11")
			input = KeyCode.Joystick1Button11;
		else if (charCode == "Joystick1Button12")
			input = KeyCode.Joystick1Button12;
		else if (charCode == "Joystick1Button13")
			input = KeyCode.Joystick1Button13;
		else if (charCode == "Joystick1Button14")
			input = KeyCode.Joystick1Button14;
		else if (charCode == "Joystick1Button15")
			input = KeyCode.Joystick1Button15;
		else if (charCode == "Joystick1Button16")
			input = KeyCode.Joystick1Button16;
		else if (charCode == "Joystick1Button17")
			input = KeyCode.Joystick1Button17;
		else if (charCode == "Joystick1Button18")
			input = KeyCode.Joystick1Button18;
		else if (charCode == "Joystick1Button19")
			input = KeyCode.Joystick1Button19;
		else if (charCode == "JoystickButton0")
			input = KeyCode.JoystickButton0;
		else if (charCode == "JoystickButton1")
			input = KeyCode.JoystickButton1;
		else if (charCode == "JoystickButton2")
			input = KeyCode.JoystickButton2;
		else if (charCode == "JoystickButton3")
			input = KeyCode.JoystickButton3;
		else if (charCode == "JoystickButton4")
			input = KeyCode.JoystickButton4;
		else if (charCode == "JoystickButton5")
			input = KeyCode.JoystickButton5;
		else if (charCode == "JoystickButton6")
			input = KeyCode.JoystickButton6;
		else if (charCode == "JoystickButton7")
			input = KeyCode.JoystickButton7;
		else if (charCode == "JoystickButton8")
			input = KeyCode.JoystickButton8;
		else if (charCode == "JoystickButton9")
			input = KeyCode.JoystickButton9;
		else if (charCode == "JoystickButton10")
			input = KeyCode.JoystickButton10;
		else if (charCode == "JoystickButton11")
			input = KeyCode.JoystickButton11;
		else if (charCode == "JoystickButton12")
			input = KeyCode.JoystickButton12;
		else if (charCode == "JoystickButton13")
			input = KeyCode.JoystickButton13;
		else if (charCode == "JoystickButton14")
			input = KeyCode.JoystickButton14;
		else if (charCode == "JoystickButton15")
			input = KeyCode.JoystickButton15;
		else if (charCode == "JoystickButton16")
			input = KeyCode.JoystickButton16;
		else if (charCode == "JoystickButton17")
			input = KeyCode.JoystickButton17;
		else if (charCode == "JoystickButton18")
			input = KeyCode.JoystickButton18;
		else if (charCode == "JoystickButton19")
			input = KeyCode.JoystickButton19;
		else if (charCode == "Joystick2Button1")
			input = KeyCode.Joystick2Button1;
		else if (charCode == "Joystick2Button2")
			input = KeyCode.Joystick2Button2;
		else if (charCode == "Joystick2Button3")
			input = KeyCode.Joystick2Button3;
		else if (charCode == "Joystick2Button4")
			input = KeyCode.Joystick2Button4;
		else if (charCode == "Joystick2Button5")
			input = KeyCode.Joystick2Button5;
		else if (charCode == "Joystick2Button6")
			input = KeyCode.Joystick2Button6;
		else if (charCode == "Joystick2Button7")
			input = KeyCode.Joystick2Button7;
		else if (charCode == "Joystick2Button8")
			input = KeyCode.Joystick2Button8;
		else if (charCode == "Joystick2Button9")
			input = KeyCode.Joystick2Button9;
		else if (charCode == "Joystick2Button10")
			input = KeyCode.Joystick2Button10;
		else if (charCode == "Joystick2Button11")
			input = KeyCode.Joystick2Button11;
		else if (charCode == "Joystick2Button12")
			input = KeyCode.Joystick2Button12;
		else if (charCode == "Joystick2Button13")
			input = KeyCode.Joystick2Button13;
		else if (charCode == "Joystick2Button14")
			input = KeyCode.Joystick2Button14;
		else if (charCode == "Joystick2Button15")
			input = KeyCode.Joystick2Button15;
		else if (charCode == "Joystick2Button16")
			input = KeyCode.Joystick2Button16;
		else if (charCode == "Joystick2Button17")
			input = KeyCode.Joystick2Button17;
		else if (charCode == "Joystick2Button18")
			input = KeyCode.Joystick2Button18;
		else if (charCode == "Joystick2Button19")
			input = KeyCode.Joystick2Button19;
		else if (charCode == "a")
			input = KeyCode.A;
		else if (charCode == "b")
			input = KeyCode.B;
		else if (charCode == "c")
			input = KeyCode.C;
		else if (charCode == "d")
			input = KeyCode.D;
		else if (charCode == "e")
			input = KeyCode.E;
		else if (charCode == "f")
			input = KeyCode.F;
		else if (charCode == "g")
			input = KeyCode.G;
		else if (charCode == "h")
			input = KeyCode.H;
		else if (charCode == "i")
			input = KeyCode.I;
		else if (charCode == "j")
			input = KeyCode.J;
		else if (charCode == "k")
			input = KeyCode.K;
		else if (charCode == "l")
			input = KeyCode.L;
		else if (charCode == "m")
			input = KeyCode.M;
		else if (charCode == "n")
			input = KeyCode.N;
		else if (charCode == "o")
			input = KeyCode.O;
		else if (charCode == "p")
			input = KeyCode.P;
		else if (charCode == "q")
			input = KeyCode.Q;
		else if (charCode == "r")
			input = KeyCode.R;
		else if (charCode == "s")
			input = KeyCode.S;
		else if (charCode == "t")
			input = KeyCode.T;
		else if (charCode == "u")
			input = KeyCode.U;
		else if (charCode == "v")
			input = KeyCode.V;
		else if (charCode == "w")
			input = KeyCode.W;
		else if (charCode == "x")
			input = KeyCode.X;
		else if (charCode == "y")
			input = KeyCode.Y;
		else if (charCode == "z")
			input = KeyCode.Z;

		return input;
	}
}
