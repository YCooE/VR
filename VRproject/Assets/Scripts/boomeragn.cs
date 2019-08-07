using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class boomeragn : MonoBehaviour
{
    SteamVR_TrackedObject trackedObject;
    SteamVR_Controller.Device device;

    // Start is called before the first frame update
    public Rigidbody rb;
    public float throwForce = 50;
    public Transform target;
    private bool isReturning = false;

    void Awake()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Throw();
            Debug.Log("Holding down the trigger");
        }
    }

    void Throw()
    {
        isReturning = false;
        rb.transform.parent = null;
        rb.isKinematic = false;
        rb.AddForce(Camera.main.transform.TransformDirection(Vector3.forward) * throwForce);
        rb.AddTorque(rb.transform.TransformDirection(Vector3.right) * 100, ForceMode.Impulse);

    }

    void Return()
    {
        isReturning = true;
        rb.position += target.position - rb.position;
    }
    //input 2.0
}
