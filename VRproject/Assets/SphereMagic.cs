﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SphereMagic : MonoBehaviour
{
    // a reference to the action
    public SteamVR_Action_Boolean SphereOnOff = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("SphereMagic");

    // a reference to the hand
    public SteamVR_Input_Sources handType;

    //reference to the sphere/gameobject
    public GameObject Sphere;

    // Start is called before the first frame update
    void Start()
    {
        SphereOnOff.AddOnStateDownListener(TriggerDown, handType);
        SphereOnOff.AddOnStateUpListener(TriggerUp, handType);
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is up");
        Sphere.GetComponent<MeshRenderer>().enabled = false;
    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is down");
        Sphere.GetComponent<MeshRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
