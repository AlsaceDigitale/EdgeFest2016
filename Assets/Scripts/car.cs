using UnityEngine;
using System.Collections;

public class car : MonoBehaviour {

	Vector3 OriginalPos;
	// Use this for initialization
	void Start () {
		OriginalPos = GetComponent<Rigidbody> ().position;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10);
		if (GetComponent<Rigidbody> ().position.z < -10) {
			GetComponent<Rigidbody> ().position = OriginalPos;
		}
	}
}
