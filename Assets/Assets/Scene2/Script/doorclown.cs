using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorclown : MonoBehaviour
{
    public GameObject doorclownfirst;
    public GameObject doorclownsecond;

    void Start()
    {
        doorclownfirst.SetActive(true);
        doorclownsecond.SetActive(false);
    }


    void Update()
    {
        if(DoorOpenClose.DoorClownisOpen)
        {
            doorclownfirst.SetActive(false);
            doorclownsecond.SetActive(true);
        }
        if(!DoorOpenClose.DoorClownisOpen)
        {
            doorclownfirst.SetActive(true);
            doorclownsecond.SetActive(false);
        }
    }
}
