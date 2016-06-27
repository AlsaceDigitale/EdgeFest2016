using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	public List<GameObject> hazards;
	public Vector3 spawnValues;
	public float startWait;
	public float waveWait;
	private int index;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWait);
		index = 0;
		while (true) {
			if (index >= hazards.Count)
				index = 0;
			
			GameObject hazard = hazards[index++];

			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (hazard, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (waveWait);
		}
	}
}
