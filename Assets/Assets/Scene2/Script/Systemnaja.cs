using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Systemnaja : MonoBehaviour
{

    [Header("DuckRoom")]
    public bool DuckComplete1;
    public bool DuckComplete2;
    public bool DuckComplete3;

    [Header("PigRoom")]
    public bool PigComplete1;
    public bool PigComplete2;
    public bool PigComplete3;

    [Header("ClownRoom")]
    public bool ClownComplete1;
    public bool ClownComplete2;
    public bool ClownComplete3;

    [Header("CatRoom")]
    public bool CatComplete1;
    public bool CatComplete2;
    public bool CatComplete3;
    
    [Header("Check")]
    public bool DuckRoomComplete;
    public bool PigRoomComplete;
    public bool ClownRoomComplete;
    public bool CatRoomComplete;

    [Header("Goal")]
    public bool Scene2Complete = false;

    [Header("Player")]
    public GameObject Player;
    
    public void Start() 
    {
        DuckComplete1 = false;
        DuckComplete2 = false;
        DuckComplete3 = false;

        PigComplete1 = false;
        PigComplete2 = false;
        PigComplete3 = false;
    
        ClownComplete1 = false;
        ClownComplete2 = false;
        ClownComplete3 = false;

        CatComplete1 = false;
        CatComplete2 = false;
        CatComplete3 = false;

        DuckRoomComplete = false;
        PigRoomComplete = false;
        ClownRoomComplete = false;
        CatRoomComplete = false;

        Scene2Complete = false;
    }

    public void Update()
    {
        if(DuckComplete1 && DuckComplete2 && DuckComplete3)
        {
            DuckRoomComplete = true;
        }

        if(PigComplete1 && PigComplete2 && PigComplete3)
        {
            PigRoomComplete = true;
        }

        if(ClownComplete1 && ClownComplete2 && ClownComplete3)
        {
            ClownRoomComplete = true;
        }

        if(CatComplete1 && CatComplete2 && CatComplete3)
        {
            CatRoomComplete = true;
        }

        if(DuckRoomComplete && PigRoomComplete && ClownRoomComplete && CatRoomComplete)
        {
            Scene2Complete = true;
            Debug.Log("Scene2Complete");
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("DuckComplete1 " + DuckComplete1);
            Debug.Log("DuckComplete2 " + DuckComplete2);
            Debug.Log("DuckComplete3 " + DuckComplete3);
        }
    }

    
}
