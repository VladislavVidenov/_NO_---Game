using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {

    [SerializeField][Range(1, 50)] int shootingSpeed;
    [SerializeField][Range(1, 10)] float distanceFromPlayer;

    private Transform player;
    private Transform holdingObjectTransform;
    private UIController uiMessage;
    private bool objectHighlighted;
    private bool holdingObject;

    private Rigidbody rb;
    public AudioBehaviour audioBehaviour;
    [HideInInspector]
    public bool fridgeSoundPlayed = false;
    [HideInInspector]
    public bool computerSoundPlayed = false;
    [HideInInspector]
    public bool picturesSoundPlayed = false;
    [HideInInspector]
    public bool booksSoundPlayed = false;

    void Start()
    {
        player = GetComponent<Transform>();
        if (GameObject.Find("HUD"))uiMessage = GameObject.Find("HUD").GetComponent<UIController>();
        audioBehaviour = GetComponentInChildren<AudioBehaviour>();
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
                    if (objectHit.name == "fridge" && fridgeSoundPlayed == false)
                    {
                        audioBehaviour.audioSource.PlayOneShot(audioBehaviour.level1Sounds[1]);
                        StartCoroutine("soundPlayed01", audioBehaviour.level1Sounds[1].length);
                        objectHit.tag = "Untagged";
                    }
                    else if (objectHit.name == "computer" && computerSoundPlayed == false)
                    {
                        audioBehaviour.audioSource.PlayOneShot(audioBehaviour.level1Sounds[2]);
                        StartCoroutine("soundPlayed02", audioBehaviour.level1Sounds[2].length);
                        objectHit.tag = "Untagged";
                    }
                    else if (objectHit.name == "pictureFrame" && picturesSoundPlayed == false)
                    {
                        audioBehaviour.audioSource.PlayOneShot(audioBehaviour.level1Sounds[3]);
                        StartCoroutine("soundPlayed03", audioBehaviour.level1Sounds[3].length);
                        objectHit.tag = "Untagged";
                    }
                    else if (objectHit.name == "BooksInteractive" && booksSoundPlayed == false)
                    {
                        audioBehaviour.audioSource.PlayOneShot(audioBehaviour.level1Sounds[4]);
                        StartCoroutine("soundPlayed04", audioBehaviour.level1Sounds[4].length);
                        objectHit.tag = "Untagged";
                    }
                    else {
                        holdingObject = true;
                        holdingObjectTransform = objectHit;
                        if (objectHit.GetComponent<Rigidbody>()) rb = objectHit.GetComponent<Rigidbody>();
                        else print("You have to add a rigidbody component to that you silly :')");
                    }
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

    IEnumerator soundPlayed01(float time)
    {
        yield return new WaitForSeconds(time);
        fridgeSoundPlayed = true;
    }
    IEnumerator soundPlayed02(float time)
    {
        yield return new WaitForSeconds(time);
        computerSoundPlayed = true;
    }
    IEnumerator soundPlayed03(float time)
    {
        yield return new WaitForSeconds(time);
        picturesSoundPlayed = true;
    }
    IEnumerator soundPlayed04(float time)
    {
        yield return new WaitForSeconds(time);
        booksSoundPlayed = true;
    }


}
