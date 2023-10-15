using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownGamePlay : MonoBehaviour
{
    [Header("Raycast")]
    public float rangeF = 1;
    public float rangeB = 1;
    public LayerMask floor;

    [Header("Phase1")]
    public float RanNum1;
    public bool TimeStartF1;
    public float timeF1;
    public bool TimeStartB1;
    public float timeB1;
    public bool TimeFinishF1;
    public bool TimeFinishB1;
    public float RanNum2;
    public bool TimeFinishF2;
    public bool TimeFinishB2;
    public float RanNum3;
    public bool TimeFinishF3;
    public bool TimeFinishB3;
    public float RanNum4;
    public bool TimeFinishF4;
    public bool TimeFinishB4;

    ClownPicture clownpicture;
    [SerializeField] GameObject gameObject;
    DoorOpenClose dooropenclose;
    [SerializeField] GameObject Player;

    void Start()
    {
        clownpicture = gameObject.GetComponent<ClownPicture>();
        dooropenclose = Player.GetComponent<DoorOpenClose>();
        RanNum1 = Random.Range(20, 40);
        RanNum2 = RanNum1 + Random.Range(30, 60);
        RanNum3 = RanNum2 + Random.Range(30, 50);
        RanNum4 = RanNum3 + Random.Range(15,25);
        TimeStartF1 = false;
        timeF1 = 0f;
        TimeStartB1 = false;
        timeB1 = 0f;
        TimeFinishB1 = false;
        TimeFinishF1 = false;
        TimeFinishF3 = false;
        TimeFinishB3 = false;
    }

    void Update()
    {
        if(!clownpicture.equipped && !clownpicture.FinishThisPic)
        {
            RayCheck();
        }
        if(!clownpicture.FinishThisPic)
        {
            Setting();
        }
        Phase();
    }

    void Setting()
    {
        if(TimeStartF1)
        {
            timeF1 += Time.deltaTime;
        }

        if(TimeStartB1)
        {
            timeB1 += Time.deltaTime;
        }
//----------------------------------------
        if(timeF1 >= RanNum1 && timeF1 < RanNum2)
        {
            TimeFinishF1 = true;
        }

        if(timeB1 >= RanNum1 && timeB1 < RanNum2)
        {
            TimeFinishB1 = true;
        }
//---------------------------------------------
        if(timeF1 >= RanNum2)
        {
            TimeFinishF2 = true;
            TimeFinishF1 = false;
        }

        if(timeB1 >= RanNum2)
        {
            TimeFinishB2 = true;
            TimeFinishB1 = false;
        }
//---------------------------------------------
        if(timeF1 >= RanNum3)
        {
            TimeFinishF3 = true;
            TimeFinishF1 = false;
            TimeFinishF2 = false;
        }
        if(timeB1 >= RanNum3)
        {
            TimeFinishB3 = true;
            TimeFinishB1 = false;
            TimeFinishB2 = false;
        }
//---------------------------------------------
        if(timeF1 >= RanNum4)
        {
            TimeFinishF4 = true;
            TimeFinishF1 = false;
            TimeFinishF2 = false;
            TimeFinishB3 = false;
        }     
        if(timeB1 >= RanNum4)
        {
            TimeFinishB4 = true;
            TimeFinishB1 = false;
            TimeFinishB2 = false;
            TimeFinishB3 = false;
        }   
//Reset time

        if(clownpicture.InRoomDuck && dooropenclose.timeduck >= 9)
        {
            timeF1 = 0;
            timeB1 = 0;
            TimeFinishF1 = false;
            TimeFinishF2 = false;
            TimeFinishF3 = false;
            TimeFinishB1 = false;
            TimeFinishB2 = false;
            TimeFinishB3 = false;
        }
        
        if(clownpicture.InRoomCat && dooropenclose.timecat >= 9)
        {
            timeF1 = 0;
            timeB1 = 0;
            TimeFinishF1 = false;
            TimeFinishF2 = false;
            TimeFinishF3 = false;
            TimeFinishB1 = false;
            TimeFinishB2 = false;
            TimeFinishB3 = false;
        }

        if(clownpicture.InRoomClown && dooropenclose.timeclown >= 9)
        {
            timeF1 = 0;
            timeB1 = 0;
            TimeFinishF1 = false;
            TimeFinishF2 = false;
            TimeFinishF3 = false;
            TimeFinishB1 = false;
            TimeFinishB2 = false;
            TimeFinishB3 = false;
        }

        if(clownpicture.InRoomPig && dooropenclose.timepig >= 9)
        {
            timeF1 = 0;
            timeB1 = 0;
            TimeFinishF1 = false;
            TimeFinishF2 = false;
            TimeFinishF3 = false;
            TimeFinishB1 = false;
            TimeFinishB2 = false;
            TimeFinishB3 = false;
        }

        if(clownpicture.FinishThisPic)
        {
            TimeStartF1 = false;
            TimeStartB1 = false;
        }

        if(clownpicture.equipped)
        {
            TimeStartF1 = true;
            TimeStartB1 = true;
        }
    }

    void RayCheck()
    {
        Vector3 directionF = Vector3.left;
        Ray theRayF = new Ray(transform.position, transform.TransformDirection(directionF * rangeF));
        Debug.DrawRay(transform.position, transform.TransformDirection(directionF * rangeF), Color.red);

        RaycastHit hit;
        if (Physics.Raycast(theRayF, out hit, rangeF, floor))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("floor"))
            {
                Debug.Log("red Hit floor");
                TimeStartF1 = false;
            }
        }

        if (!Physics.Raycast(theRayF, out hit, rangeF, floor))
        {
            Debug.Log("red null");
            TimeStartF1 = true;
        }
//------------------------------------------------------------------------------------------------------------------------
        Vector3 directionB = Vector3.right;
        Ray theRayB = new Ray(transform.position, transform.TransformDirection(directionB * rangeB));
        Debug.DrawRay(transform.position, transform.TransformDirection(directionB * rangeB), Color.green);
        
        if (Physics.Raycast(theRayB, out hit, rangeB, floor))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("floor"))
            {
                Debug.Log("green Hit floor");
                TimeStartB1 = false;
            }
        }
        if (!Physics.Raycast(theRayB, out hit, rangeB, floor))
        {
            Debug.Log("green null");
            TimeStartB1 = true;
        }
    }

    void Phase()
    {   
        // F1 & B1 is mean "phase 1 Front & Back
        //Duck Model

        if(TimeFinishF1)
        {
            //enable model F1
        }
        if(TimeFinishB1)
        {
            //enable model B1
        }
        if(TimeFinishF2)
        {
            //enable model F2
        }
        if(TimeFinishB2)
        {
            //enable model B2
        }
        if(TimeFinishB3)
        {
            //enable model B3
        }
        if(TimeFinishF4 || TimeFinishB4)
        {
            //UI GameOver
            //Back to Scene 2 again
            Debug.Log("Clown GameOver");
        }
    //-------------------------------------------------
        if(!TimeFinishF1)
        {
            //disable model F1
        }
        if(!TimeFinishB1)
        {
            //disable model B1
        }
        if(!TimeFinishF2)
        {
            //disable model F2
        }
        if(!TimeFinishB2)
        {
            //disable model B2
        }
        if(!TimeFinishB3)
        {
            //disable model B3
        }
//-----------------------------------------------------------
        if(clownpicture.FinishThisPic)
        {   
            timeF1 = 0f;
            timeB1 = 0f;
            TimeStartF1 = false;
            TimeStartB1 = false;
            TimeFinishF1 = false;
            TimeFinishF2 = false;
            TimeFinishF3 = false;
            TimeFinishB1 = false;
            TimeFinishB2 = false;
            TimeFinishB3 = false;
        }

    }
}

