using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Sendout : MonoBehaviour
{
    // a reference to the action
    public SteamVR_Action_Boolean sendout;

    // a reference to the hand
    public SteamVR_Input_Sources handType;

    //reference to the sphere/gameobject
    public GameObject Position;

    public bool Nice = false;

    // Start is called before the first frame update
    void Start()
    {
        sendout.AddOnStateDownListener(Touch1, handType);
        sendout.AddOnStateUpListener(Touch2, handType);
    }

    public void Touch1(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Touching is up");
        Nice = false;
    }
    public void Touch2(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Nah");
        Nice = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Nice)
        {
            transform.position = Position.transform.position + Vector3.forward * 10f;
        }
    }
}
