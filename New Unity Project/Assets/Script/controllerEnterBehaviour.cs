using UnityEngine;
using System.Collections;

public class controllerEnterBehaviour : MonoBehaviour {

    private AudioBehaviour audioBehaviour;


    [HideInInspector]
    public Animator doorAnimator;
    public GameObject door;
	public GameObject particles1;
	public GameObject particles2;
	public Light light;
	private float fading = 0f;
	public float fadeRate = 10f;
	public float fadeTo = 2f;
	private bool lightStart = false;
    [Header("Scene Transition")]
    public float transitionTime = 0;
    public int goToLevel = 0;
    void Start()
    {
        doorAnimator = door.GetComponent<Animator>();
        audioBehaviour = GetComponentInChildren<AudioBehaviour>();
    }

	void Update()
	{
		if (lightStart) {
			fading += Time.deltaTime * fadeRate;
			light.intensity = Mathf.Lerp (.2f,fadeTo,fading);
		}
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            doorAnimator.SetInteger("doorBehaviour", 2);
			particles1.SetActive (false);
			particles2.SetActive (true);
			lightStart = true;
            audioBehaviour.audioSource.PlayOneShot(audioBehaviour.FX[1]);
            StartCoroutine("SwitchToLevel", transitionTime);

        }
    }

    IEnumerator SwitchToLevel (float waitTime)
    {
        yield return new WaitForSeconds(1);
        FadeManager.instance.FadeWhiteScreen(true);
        yield return new WaitForSeconds(waitTime);
        GameManager.Instance.ResetKeysCollected();
        GameManager.Instance.sceneManger.SwitchToLevel(goToLevel);
    }
}
