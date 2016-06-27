using UnityEngine;
using System.Collections;

public class car : MonoBehaviour {

	public int speed = 10;

	Vector3 OriginalPos;
	// Use this for initialization
	void Start () {
		OriginalPos = GetComponent<Rigidbody> ().position;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
	}
}
