using UnityEngine;
using System.Collections;

public class TriggerSocket : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
		Animator socketAnimator = GameObject.Find ("crane").GetComponent<Animator> ();
		if (other.name == "pickupBall") {
			Debug.Log ("ball in place");
			socketAnimator.SetInteger("craneMove", 1); 
        }
    }
}
