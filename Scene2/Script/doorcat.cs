using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorcat : MonoBehaviour
{
    public GameObject doorcatfirst;
    public GameObject doorcatsecond;

    void Start()
    {
        doorcatfirst.SetActive(true);
        doorcatsecond.SetActive(false);
    }


    void Update()
    {
        if(DoorOpenClose.DoorCatisOpen)
        {
            doorcatfirst.SetActive(false);
            doorcatsecond.SetActive(true);
        }
        if(!DoorOpenClose.DoorCatisOpen)
        {
            doorcatfirst.SetActive(true);
            doorcatsecond.SetActive(false);
        }
    }
}

