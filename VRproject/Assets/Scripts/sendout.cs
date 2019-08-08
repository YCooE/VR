using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendout : MonoBehaviour
{

    public Hand hand;
    public GameObject rigidHand;
    public SteamVR_Action_Boolean Sendout;
    public Transform target;
    private bool isReturning = false;

    // OnEnable is called after Awake, initializes
    void OnEnable()
    {
        if (hand == null)
            hand = this.GetComponent<Hand>;
        if (Sendout == null)
        {
            Debug.LogError("<b>[SteamVR Interaction] </b> No sendout action assigned");
            return;
        }
        Sendout.AddOnChangeListener(OnSendOut, hand.handType);
    }

    private void OnDisable()
    {
        if(Sendout != null)
        {
            Sendout.RemoveOnChangeListerner(OnSendOut, hand.handType);
        }
    }

    private void OnSendOut(SteamVR_Action_Boolean actionIN, SteamVR_Input_Sources inputSources, bool newValue)
    {
        if (newValue)
        {
            Send();
        }
    }

    public void Send()
    {
        StartCoroutine(DoPlan());
    }

    private IEnumerator DoPlant()
    {
        float throwForce = 50.0;
        Vector3 handPos;

        RigidBody rigidbody = sendout.GetComponent<Rigidbody>();

        if(rigidbody != null)
        {
            rigidbody.isKinematic = true;
        }
        float startTime = Time.time;
        float overTime = 3.0f;
        float endTime = startTime + overTime;

        while(startTime < endTime)
        {
            rigidbody.transform.parent = null;
            rigidbody.AddForce(Camera.main.transform.TransformDirection(Vector3.forward) * throwForce);
            rigidbody.AddTorque(rigidbody.transform.TransformDirection(Vector3.right) * 100, ForceMode.Impulse);
            yield return null;
        }


        if(rigidbody != null)
        {
            rigidbody.isKinematic = false;
        }
    }


    void Return()
    {
        isReturning = true;
        rb.position += target.position - rb.position;
    }
}
