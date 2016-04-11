using UnityEngine;
using System.Collections;

public class BridgeSocketScript : MonoBehaviour {
    
    [SerializeField]private GameObject[] objectsToSpawn;

    void Start() {
        for (int i = 0; i < objectsToSpawn.Length; i++) {
            objectsToSpawn[i].SetActive(false);
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.transform.tag == "Interactable") {
            for (int i = 0; i < objectsToSpawn.Length; i++) {
                objectsToSpawn[i].SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.transform.tag == "Interactable") {
            if (collider.transform.tag == "Interactable") {
                for (int i = 0; i < objectsToSpawn.Length; i++) {
                    objectsToSpawn[i].SetActive(false);
                }
            }
        }
    }
}
