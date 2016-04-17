using UnityEngine;
using System.Collections;

public class TombTrigger : MonoBehaviour {

    private AudioBehaviourL6 audioBehaviour;

	void Start () {
        audioBehaviour = GameObject.FindObjectOfType<AudioBehaviourL6>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            audioBehaviour.audioSource.PlayOneShot(audioBehaviour.levelSounds[0]);
        }
    }
}
