using UnityEngine;
using System.Collections;

public class HospitalEnter : MonoBehaviour {

    private AudioBehaviourL5 audioBehaviour;

    void Start () {
        audioBehaviour = GameObject.FindObjectOfType<AudioBehaviourL5>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            audioBehaviour.audioSource.PlayOneShot(audioBehaviour.levelSounds[1]);
        }
    }
}
