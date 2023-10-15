using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorduck : MonoBehaviour
{
    public GameObject doorduckfirst;
    public GameObject doorducksecond;

    void Start()
    {
        doorduckfirst.SetActive(true);
        doorducksecond.SetActive(false);
    }


    void Update()
    {
        if(DoorOpenClose.DoorDuckisOpen)
        {
            doorduckfirst.SetActive(false);
            doorducksecond.SetActive(true);
        }
        if(!DoorOpenClose.DoorDuckisOpen)
        {
            doorduckfirst.SetActive(true);
            doorducksecond.SetActive(false);
        }
    }
}
