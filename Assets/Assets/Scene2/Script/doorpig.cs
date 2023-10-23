using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorpig : MonoBehaviour
{
    public GameObject doorpigfirst;
    public GameObject doorpigsecond;

    void Start()
    {
        doorpigfirst.SetActive(true);
        doorpigsecond.SetActive(false);
    }


    void Update()
    {
        if(DoorOpenClose.DoorPigisOpen)
        {
            doorpigfirst.SetActive(false);
            doorpigsecond.SetActive(true);
        }
        if(!DoorOpenClose.DoorPigisOpen)
        {
            doorpigfirst.SetActive(true);
            doorpigsecond.SetActive(false);
        }
    }
}
