using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {

    public GameObject spawnPoint;

    void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            other.transform.position = spawnPoint.transform.position;
        }
    }
}
