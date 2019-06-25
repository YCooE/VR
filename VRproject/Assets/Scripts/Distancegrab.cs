using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Distancegrab : MonoBehaviour
{
    SteamVR_TrackedObject trackedObject;
    SteamVR_Controller.Device device; 
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
}
