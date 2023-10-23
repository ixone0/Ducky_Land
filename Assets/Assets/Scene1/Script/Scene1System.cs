using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scene1System : MonoBehaviour
{
    [Header("Timer")]
    public float time;
    public bool TimeStart;
    [SerializeField] TextMeshProUGUI timerText; 

    [Header("Component")]
    public bool Button1;
    public bool Button2;
    public bool Button3;
    public bool Button4;
    public bool Button5;

    [Header("UI")]
    public bool GameOver;
    public bool Scene1Complete;
    int minutes;
    int seconds;

    [Header("Player")]
    [SerializeField] GameObject Player;
    FirstPersonController firstPersonController;

    void Start()
    {
        firstPersonController = Player.GetComponent<FirstPersonController>();
        TimeStart = false;  
        Button1 = false;
        Button2 = false;
        Button3 = false;
        Button4 = false;
        Button5 = false;
        GameOver = false;
        Scene1Complete = false;
        timerText.enabled = false;
        time = 180;
    }

    void Update()
    {     

        Timer();
        SystemScene1();

    }


    void Timer()
    {
        
        if(TimeStart)
        {
            timerText.enabled = true;
            time -= Time.deltaTime;
            minutes = Mathf.FloorToInt(time / 60);
            seconds = Mathf.FloorToInt(time % 60);
        }
        if(time <= 0)
        {
            time = 0;
            GameOver = true;
            TimeStart = false;
            minutes = 0;
            seconds = 0;
            firstPersonController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
        if(time > 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void SystemScene1()
    {

        if(Button1 && Button2 && Button3 && Button4 && Button5)
        {
            Debug.Log("Scene1Complete");
            Scene1Complete = true;
        }

        if(GameOver)
        {
            //UI GameOver and then ResetScene
        }

    }

    
}
