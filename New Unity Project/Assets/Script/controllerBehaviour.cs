using UnityEngine;
using System.Collections;

public class controllerBehaviour : MonoBehaviour {

    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }
}
