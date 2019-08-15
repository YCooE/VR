using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script works like absolute arse
// Cant grab, vector doesnt work, can only slightly nudge sometimes
// f

//[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Potatograb : MonoBehaviour {
    /*
    //public Rigidbody handtosend;
    public Transform sphere;
    public Transform target;
    public Transform curve_point;
    public float throwForce = 50;

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    private float time = 0.0f;

    private bool reTurning = false;

    private Vector3 old_pos;
    FixedJoint fixedJoint;
    void Start()
    {
        //rb = GetComponent<RigidBody>();
    }
    void Awake () 
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

	void FixedUpdate ()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("You activated PressUp on the Touchpad");
            sphere.transform.position = Vector3.zero;
            sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
            sphere.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("Adding force");
            Forcefire();
        }

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            ReturnForce();
        }

        if (reTurning == true)
        {
          if (time < 1.0f)
          {
            handtosend.position = getBQCPoint(time, old_pos, curve_point.position, target.position);
            time += Time.deltaTime;
          }
          else
          {
            Reset();
          }
        }


    }

    void OnTriggerStay(Collider col)
    {
        Debug.Log("You have collided with " + col.name + " and activated OnTriggerStay");
        if (fixedJoint == null && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
            fixedJoint = col.gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = handtosend;
        }
        else if (fixedJoint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject go = fixedJoint.gameObject;
            Rigidbody rigidBody = go.GetComponent<Rigidbody>();
            Object.Destroy(fixedJoint);
            fixedJoint = null;
            tossObject(rigidBody);
        }
    }

    void tossObject(Rigidbody rigidBody)
    {
        Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
        if (origin != null)
        {
            rigidBody.velocity = origin.TransformVector(device.velocity);
            rigidBody.angularVelocity = origin.TransformVector(device.angularVelocity);
        }
        else
        {
            rigidBody.velocity = device.velocity;
            rigidBody.angularVelocity = device.angularVelocity;
        }

    }
    /*
    void Forcefire()
    {
        handtosend.transform.parent = null;
        handtosend.isKinematic = false;

        handtosend.AddForce(Camera.main.transform.TransformDirection(Vector3.forward) * throwForce, ForceMode.Impulse);

        handtosend.AddTorque(Camera.main.transform.TransformDirection(Vector3.right) * 100, ForceMode.Impulse);


    }

    void ReturnForce()
    {
       time = 0.0f;

       reTurning = true;

       old_pos = handtosend.position;

       handtosend.velocity = Vector3.zero;

       handtosend.isKinematic = true;


    }

    void Reset()
    {
      reTurning = false;

      handtosend.transform.parent = transform;

      handtosend.position = target.position;

      handtosend.rotation = target.rotation;
    }

    Vector3 getBQCPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
      float u = 1 - t;
      float tt = t * t;
      float uu = u * u;

      Vector3 p = (uu * p0) + (2 * u * t * p1) + (tt * p2);
      return p;
    }
    */
}
