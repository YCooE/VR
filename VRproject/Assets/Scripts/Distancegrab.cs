using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Distancegrab : MonoBehaviour
{
    SteamVR_TrackedObject trackedObject;
    SteamVR_Controller.Device device;

    //Making it a rigidbody

    //public Rigidbody hand;

    //This may be redundant
    /*
    void Start()
    {
        rb = GetComponent<RigidBody>();
    }
    */

    // Awake is called when program is called
    void Awake()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    // Fixedupdate is every frame 90 frames per second
    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("Holding down the trigger");
        }
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("Touchdown the trigger");
        }
        /*
        if (device.GetTouchDown(EVRButtonId.k_EButton_SteamVR_Touchpad))
        {
            Debug.Log("Touchdown on touch pad");
            addForce();
        }
        */
    }

    void OnTriggerStay(Collider col)
    {
        Debug.Log("Trigger stay");
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("Collision");
            col.gameObject.transform.SetParent(gameObject.transform);
            col.attachedRigidbody.isKinematic = true;
        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            col.gameObject.transform.SetParent(null);
            col.attachedRigidbody.isKinematic = false;

            tossObject(col.attachedRigidbody);
        }
    }
    
    void tossObject(Rigidbody rigid)
    {
        // if origin exist nice, if not we take the parent
        Transform origin = trackedObject.origin ? trackedObject.origin : trackedObject.transform.parent;
        if (origin != null)
        {
            rigid.velocity = origin.TransformVector(device.velocity);
            rigid.angularVelocity = origin.TransformVector(device.angularVelocity);
        }
        else
        {
            rigid.velocity = device.velocity;
            rigid.angularVelocity = device.angularVelocity;
        }
    }

    // Add a force to the hand
    /*
    void addForce()
    {
        hand.isKinematic = false;

        hand.AddForce(Camera.main.transform.TransformDirection(Vector3.forward) * throwForce);
    }
    */
}
