using UnityEngine;
using System.Collections;

public class car : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10);
	}
}
