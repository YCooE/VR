using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    SteamVR_TrackedObject trackedObject;
    SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObject.index);
    // Awake is called when program is called
    void Awake()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    // Fixedupdate is every frame 90 frames per second
    void FixedUpdate()
    {
        if(device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
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
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)
        {
            Debug.Log("Collision");
            col.gameObject.transform.SetParent(gameObject.transform);
            col.attachedRigidbody.isKinematic = true;
        }
    }
}
