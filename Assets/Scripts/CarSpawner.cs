using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour {

	public GameObject car;
	public GameObject player;

	Player p;

	bool carIsBehind;
	float timeBehind;
	float rndTime;

	// Use this for initialization
	void Start () {
		p = player.GetComponent<Player> ();
		carIsBehind = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (p.isAlive ()) {
			if (car.transform.position.z < player.transform.position.z - 10) {
				if (!carIsBehind) {
					timeBehind = 0;
					rndTime = Random.value * 3;
				}
				timeBehind += Time.deltaTime;
				carIsBehind = true;
			}

			if (carIsBehind && timeBehind > rndTime) {
				car.GetComponent<car> ().resetPosition ();
				carIsBehind = false;
			}
		}
	}
}
