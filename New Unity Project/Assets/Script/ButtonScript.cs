using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
    private bool selected;
    new Renderer renderer;
    public bool Selected {
        get { return selected; }
        set { selected = value; }
    }
    public bool preferedState;
	void Start () {
        selected = false;
        renderer = GetComponent<Renderer>();
	}
	
	void Update () {

        if (selected) renderer.material.color = Color.green;
        else renderer.material.color = Color.clear;
	}
    void OnTriggerEnter(Collider other) {
        selected = !selected;
    }
}
