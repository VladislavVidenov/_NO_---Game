using UnityEngine;
using System.Collections;

public class TriggerSocket : MonoBehaviour {

    public Animator socketAnimator;

    void Start() {
        socketAnimator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.name == "RollerBall") {
            socketAnimator.SetInteger("craneMove", 1); 
        }
    }
}
