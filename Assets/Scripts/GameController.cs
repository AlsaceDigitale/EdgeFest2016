using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public List<GameObject> hazards;
	public Vector3 spawnValues;
	public float startWait;
	public float waveWait;

	public bool activatePump = false;

	public int startCountDown = 9;

	public GameObject overlayText;
	public GameObject overlayTextBackground;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	private int index;

	private bool isInGame = false;

	private IEnumerator playCoroutine;

	// Use this for initialization
	void Start () {
		StartCoroutine (Replay ());
		SetText("En attente de joueurs...");
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

	IEnumerator Replay () {
		while (true) {
			if (!isInGame) {
				int playerNb = 0;

				if (player1.transform.Find("troll").GetComponent<Player>().PlayerIsPresent()) {
					playerNb++;
				}
				if (player2.transform.Find("troll 2").GetComponent<Player>().PlayerIsPresent()) {
					playerNb++;
				}
				if (player3.transform.Find("troll 3").GetComponent<Player>().PlayerIsPresent()) {
					playerNb++;
				}
				if (player4.transform.Find("troll 4").GetComponent<Player>().PlayerIsPresent()) {
					playerNb++;
				}

				if (playerNb >= 2) {
					playCoroutine = Play ();
					StartCoroutine(playCoroutine);
				}
			}
			yield return new WaitForSeconds (0.5f);
		}
	}

	IEnumerator Play () {
		isInGame = true;

		int countdown = startCountDown;

		while (countdown >= 0) {
			SetText(countdown + "...");
			countdown--;
			yield return new WaitForSeconds (1);
		}

		SetText("");

		Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;

		int playerNb = 0;

		if (player1.transform.Find("troll").GetComponent<Player>().PlayerIsPresent()) {
			playerNb++;
		}
		if (player2.transform.Find("troll 2").GetComponent<Player>().PlayerIsPresent()) {
			playerNb++;
		}
		if (player3.transform.Find("troll 3").GetComponent<Player>().PlayerIsPresent()) {
			playerNb++;
		}
		if (player4.transform.Find("troll 4").GetComponent<Player>().PlayerIsPresent()) {
			playerNb++;
		}

		GameObject p1GameObject = null;
		GameObject p2GameObject = null;
		GameObject p3GameObject = null;
		GameObject p4GameObject = null;

		if (playerNb >= 2) {
			if (player1.transform.Find("troll").GetComponent<Player>().PlayerIsPresent()) {
				p1GameObject = Instantiate (player1, spawnPosition, spawnRotation) as GameObject;
			}
			if (player2.transform.Find("troll 2").GetComponent<Player>().PlayerIsPresent()) {
				p2GameObject = Instantiate (player2, spawnPosition, spawnRotation) as GameObject;
			}
			if (player3.transform.Find("troll 3").GetComponent<Player>().PlayerIsPresent()) {
				p3GameObject = Instantiate (player3, spawnPosition, spawnRotation) as GameObject;
			}
			if (player4.transform.Find("troll 4").GetComponent<Player>().PlayerIsPresent()) {
				p4GameObject = Instantiate (player4, spawnPosition, spawnRotation) as GameObject;
			}
		} else {
			isInGame = false;
		}

		var spawnWavesCoroutine = SpawnWaves ();
		StartCoroutine (spawnWavesCoroutine);

		playerNb = 4;

		bool p1alive = false;
		bool p2alive = false;
		bool p3alive = false;
		bool p4alive = false;

		while (playerNb > 1) {
			playerNb = 0;
			p1alive = false;
			p2alive = false;
			p3alive = false;
			p4alive = false;

			if (p1GameObject != null && p1GameObject.transform.Find("troll").GetComponent<Player>().isAlive()) {
				playerNb++;
				p1alive = true;
			}
			if (p2GameObject != null && p2GameObject.transform.Find("troll 2").GetComponent<Player>().isAlive()) {
				playerNb++;
				p2alive = true;
			}
			if (p3GameObject != null && p3GameObject.transform.Find("troll 3").GetComponent<Player>().isAlive()) {
				playerNb++;
				p3alive = true;
			}
			if (p4GameObject != null && p4GameObject.transform.Find("troll 4").GetComponent<Player>().isAlive()) {
				playerNb++;
				p4alive = true;
			}

			yield return new WaitForSeconds(0.5f);
		}

		if (p1GameObject != null) {
			Destroy(p1GameObject, 0);
		}
		if (p2GameObject != null) {
			Destroy(p2GameObject, 0);
		}
		if (p3GameObject != null) {
			Destroy(p3GameObject, 0);
		}
		if (p4GameObject != null) {
			Destroy(p4GameObject, 0);
		}

		if (p1alive) {
			SetText("Joueur 1 gagne !");
		} else if (p2alive) {
			SetText("Joueur 2 gagne !");
		} else if (p3alive) {
			SetText("Joueur 3 gagne !");
		} else if (p4alive) {
			SetText("Joueur 4 gagne !");
		} else {
			SetText("Tout le monde perd...");
		}

		yield return new WaitForSeconds(5.0f);

		SetText("En attente de joueurs...");

		isInGame = false;

		StopCoroutine(spawnWavesCoroutine);
		StopCoroutine(playCoroutine);
	}

	public void SetText(string t) {
		overlayText.GetComponent<Text>().text = t;
		overlayTextBackground.GetComponent<Text>().text = t;
	}

	public void ClearText() {
		overlayText.GetComponent<Text>().text = "";
		overlayTextBackground.GetComponent<Text>().text = "";
	}

	public bool IsPumpActivated() {
		return activatePump;
	}
}
