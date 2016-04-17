using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class AudioBehaviourL4 : MonoBehaviour {

    public AudioClip[] levelSounds;
    public AudioClip[] FX;
    public GameObject door;
    [HideInInspector]
    public AudioSource audioSource;

    private PickupObject pickUpObject;
    private bool interactiveSoundPlayed = false;
    private bool sound5Played = false;

    // Use this for initialization
    void Start() {
        pickUpObject = GetComponentInParent<PickupObject>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(levelSounds[0]);
        //AudioSource.PlayClipAtPoint(level1Sounds[0], transform.position);
    }
	
	
}
