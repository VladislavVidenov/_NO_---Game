using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {

    public GameObject spawnPoint;
	public GameObject ballSpawn;

    void OnTriggerEnter(Collider other) {
		if (other.name == "Player") {
			other.transform.position = spawnPoint.transform.position;
		} else if (other.name == "pickupBall") {
			other.transform.position = ballSpawn.transform.position;
		}
    }
}
