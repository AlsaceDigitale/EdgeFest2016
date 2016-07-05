using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public List<GameObject> hazards;
	public Vector3 spawnValues;
	public float startWait;
	public float waveWait;

	public GameObject overlayText;

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

	public void SetText(string t) {
		overlayText.GetComponent<Text>().text = t;
	}

	public void ClearText() {
		overlayText.GetComponent<Text>().text = "";
	}
}
