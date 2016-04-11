using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {

    [SerializeField][Range(1, 50)] int shootingSpeed;
    [SerializeField][Range(1, 10)] float distanceFromPlayer;

    private Transform player;
    private Transform holdingObjectTransform;
    private UIController uiMessage;
    private Rigidbody rb;

    private bool objectHighlighted;
    private bool holdingObject;

    void Start()
    {
        player = GetComponent<Transform>();
        if (GameObject.Find("HUD"))uiMessage = GameObject.Find("HUD").GetComponent<UIController>();
    }
    void Update() {
        if (holdingObject)
        {
            SetBallDistance();
            if (Input.GetMouseButtonDown(0)) Shoot(holdingObjectTransform);
            else if (Input.GetMouseButtonDown(1)) holdingObject = false;
        }
        else if (rb!=null)rb.useGravity = true;
        HoldObject();
    }
    void SetBallDistance()
    {
        rb.useGravity = false;
        rb.position = Camera.main.transform.position + Camera.main.transform.forward * distanceFromPlayer;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray,out hit,distanceFromPlayer))
        {
            Transform objectHit = hit.transform;
            if (objectHit.tag != "Interactable")
            {
                rb.position = hit.point;
            }
        }
    }
    void HoldObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            if (objectHit.tag == "Interactable" && holdingObject == false)
            {
                uiMessage.DisplayIcon(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    holdingObject = true;
                    holdingObjectTransform = objectHit;
                    if (objectHit.GetComponent<Rigidbody>()) rb = objectHit.GetComponent<Rigidbody>();
                    else print("You have to add a rigidbody component to that you silly :')");
                }
            }
            else
                uiMessage.DisplayIcon(false);
        }
        else uiMessage.DisplayIcon(false);
    }
    void Shoot(Transform obj)
    {
        obj.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * shootingSpeed;
        holdingObject = false;
    }
}
