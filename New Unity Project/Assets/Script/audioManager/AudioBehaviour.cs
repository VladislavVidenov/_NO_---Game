using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class AudioBehaviour : MonoBehaviour {

    public AudioClip[] level1Sounds;
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
        audioSource.PlayOneShot(level1Sounds[0]);
        //AudioSource.PlayClipAtPoint(level1Sounds[0], transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        if (pickUpObject.fridgeSoundPlayed && pickUpObject.computerSoundPlayed && pickUpObject.booksSoundPlayed && pickUpObject.picturesSoundPlayed && !interactiveSoundPlayed)
        {
            audioSource.PlayOneShot(level1Sounds[5]);
            interactiveSoundPlayed = true;
            StartCoroutine("SoundPlayed", level1Sounds[5].length);
        }
    }

    IEnumerator SoundPlayed(float time) {
        yield return new WaitForSeconds(time);
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(level1Sounds[6]);
        yield return new WaitForSeconds(50);
        door.SetActive(false);
    }
}
