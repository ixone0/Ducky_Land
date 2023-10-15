using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    [Header("Raycast")]
    public static bool DoorDuckisOpen = false;
    public static bool DoorCatisOpen = false;
    public static bool DoorClownisOpen = false;
    public static bool DoorPigisOpen = false;
    public float time;
    public bool timeStart = true;
    public RaycastHit hit;
    public Ray ray;
    public float DistanceRay;

    [Header("Timer")]
    public float timeduck;
    public float timecat;
    public float timeclown;
    public float timepig;   

    void Start()
    {
        timeStart = true;
        DistanceRay = 7f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    void Update()
    {
        DoorOption();
        timerkub();
    }

    void DoorOption()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * DistanceRay, Color.blue);
        if (Physics.Raycast(ray, out hit, DistanceRay))
        {
            if(hit.transform.tag == "DoorDuck" && Input.GetMouseButtonDown(0))
            {
                DoorDuckisOpen = !DoorDuckisOpen;
            }
            if(hit.transform.tag == "DoorCat" && Input.GetMouseButtonDown(0))
            {
                DoorCatisOpen = !DoorCatisOpen;
            }
            if(hit.transform.tag == "DoorClown" && Input.GetMouseButtonDown(0))
            {
                DoorClownisOpen = !DoorClownisOpen;
            }
            if(hit.transform.tag == "DoorPig" && Input.GetMouseButtonDown(0))
            {
                DoorPigisOpen = !DoorPigisOpen;
            }
            if(hit.transform.tag == "DoorDuck" || hit.transform.tag == "DoorCat" || hit.transform.tag == "DoorClown" || hit.transform.tag == "DoorPig")
            {
                Cursor.visible = true;
            }
            
        }
        else
        {
            Cursor.visible = false;
        }
/*
        Debug.Log("DoorDuck " + DoorDuckisOpen);
        Debug.Log("DoorCat " + DoorCatisOpen);
        Debug.Log("DoorClown " + DoorClownisOpen);
        Debug.Log("DoorPig " + DoorPigisOpen);*/
    }

    void timerkub()
    {
        if(timeStart)
        {
            time += Time.deltaTime;
        }    
        if(time > 5)
        {
            DoorDuckisOpen = true;
            DoorCatisOpen = true;
            DoorClownisOpen = true;
            DoorPigisOpen = true;
            time = 0f;
            timeStart = false;
        }
    //---------------------------------------
        if(!DoorDuckisOpen) //Duck
        {
            timeduck += Time.deltaTime;
            if(timeduck >= 10)
            {
                DoorDuckisOpen = true;
            }
        }
        if(DoorDuckisOpen)
        {
            timeduck = 0;
        }
    //--------------------------------------
        if(!DoorCatisOpen) //Cat
        {
            timecat += Time.deltaTime;
            if(timecat >= 10)
            {
                DoorCatisOpen = true;
            }
        }
        if(DoorCatisOpen)
        {
            timecat = 0;
        }
    //-----------------------------------------
        if(!DoorClownisOpen) //Clown
        {
            timeclown += Time.deltaTime;
            if(timeclown >= 10)
            {
                DoorClownisOpen = true;
            }
        }
        if(DoorClownisOpen)
        {
            timeclown = 0;
        }
    //------------------------------------------
        if(!DoorPigisOpen) //Pig
        {
            timepig += Time.deltaTime;
            if(timepig >= 10)
            {
                DoorPigisOpen = true;
            }
        }
        if(DoorPigisOpen)
        {
            timepig = 0;
        }
    }


}