using UnityEngine;
using System.Collections.Generic;

public class controllerTrigger : MonoBehaviour {

    public GameObject door;
    private Animator doorAnimator;
    private Door doorScript;
    public List<Keys> RequiredItem { get { return requiredItems; } }
    [SerializeField]
    private List<Keys> requiredItems;

    [HideInInspector]
    public bool selected = false; //This should be true when the player has all keys and entered the box collider
    


    void Start() {
        doorAnimator = door.GetComponent<Animator>();
        doorScript = GetComponent<Door>();
    }
    void OnTriggerEnter(Collider other) {
        if (other.name == "Player" && selected) {
            //print("selected = " + selected);
            doorAnimator.SetInteger("doorBehaviour", 1);
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.name == "Player" && selected) {
            doorAnimator.SetInteger("doorBehaviour", 2);
        }
    }
}
