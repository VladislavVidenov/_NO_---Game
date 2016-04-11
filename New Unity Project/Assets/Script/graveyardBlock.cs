using UnityEngine;
using System.Collections;

public class graveyardBlock : MonoBehaviour {

    public GameObject blockFence;

    void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            blockFence.SetActive(true);
        }
    }
}
