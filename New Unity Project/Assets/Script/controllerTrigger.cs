using UnityEngine;
using System.Collections;

public class controllerTrigger : MonoBehaviour {

    public GameObject door;
    private Animator doorAnimator;



    [Header("Level finish requirements")]
    int RequiredKeysToFind = 0;
    


    void Start() {
        
        doorAnimator = door.GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            doorAnimator.SetInteger("doorBehaviour", 1);
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.name == "Player") {
            doorAnimator.SetInteger("doorBehaviour", 2);
        }
    }
}
