using UnityEngine;
using System.Collections;

public class KeyPickupScript : MonoBehaviour {

    private AudioBehaviourL1 audioBehaviour;

    void Start() {
        audioBehaviour = GetComponentInChildren<AudioBehaviourL1>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioBehaviour.audioSource.PlayOneShot(audioBehaviour.FX[0]);
            GameManager.Instance.keysCollected++;
            Debug.Log("key destroyed.");
            Destroy(gameObject);
        }
    }
}
