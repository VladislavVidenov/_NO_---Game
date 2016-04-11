using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour {
    [SerializeField] private float waterLevel = 4;
    [SerializeField] private float floatHeight = 2;
    [SerializeField] private float bounceDamp = 0.5f;
    [SerializeField] private Vector3 buoyancyCenterOffset;

    private float forceFactor;
    private Vector3 actionPoint;
    private Vector3 UpLift;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        actionPoint = transform.position + buoyancyCenterOffset;
        forceFactor = 1 - ((actionPoint.y - waterLevel) / floatHeight);

        if (forceFactor > 0)
        {
            UpLift = -Physics.gravity * (forceFactor - rb.velocity.y * bounceDamp);
            rb.AddForceAtPosition(UpLift, actionPoint);
        }
    }
}
