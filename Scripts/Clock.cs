using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Image clock;
    public TextMeshProUGUI text;
    public Image hourHand;
    public Image minuteHand;
    public float rotationSpeed = 10f;
    public int correctHour;
    public int correctMinute;
    public bool playerIsClose;
    public bool isCorrect;
    void Start()
    {
        clock.gameObject.SetActive(false);
        text.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        if (!isCorrect && playerIsClose)
        { 
        if (!clock.gameObject.activeInHierarchy )
        {
            if (Input.GetKeyDown(KeyCode.E) && playerIsClose) 
            clock.gameObject.SetActive(true);
        }
        else
            {
                HandleInput();
                if (Input.GetKeyDown(KeyCode.E) && checkCorrectHour())
                {
                    isCorrect = true;
                    clock.gameObject.SetActive(false);
                }
                if (Input.GetKeyDown(KeyCode.E)) clock.gameObject.SetActive(false);
            }
        }
        
    }

 
        


    void HandleInput()
    {
        clock.gameObject.SetActive(true);
        float hourRotation = 0f;
        float minuteRotation = 0f;
  
        if (Input.GetKey(KeyCode.S))
            hourRotation = rotationSpeed * Time.deltaTime ;
        if (Input.GetKey(KeyCode.W))
            hourRotation = -rotationSpeed * Time.deltaTime ;

        if (Input.GetKey(KeyCode.A))
            minuteRotation = rotationSpeed * Time.deltaTime ;
        if (Input.GetKey(KeyCode.D))
            minuteRotation = -rotationSpeed * Time.deltaTime;

        RotateClockHands(hourRotation, minuteRotation);
        text.text = GetCurrentTime();
    }

    void RotateClockHands(float hourRotation, float minuteRotation)
    {
        Quaternion hourRotationQuat = Quaternion.Euler(0f, 0f, hourRotation);
        Quaternion minuteRotationQuat = Quaternion.Euler(0f, 0f, minuteRotation);

        // Rotate hour hand
        hourHand.transform.rotation *= hourRotationQuat;

        // Rotate minute hand
        minuteHand.transform.rotation *= minuteRotationQuat;
    }

    public string GetCurrentTime()
    {
        int hour = Mathf.RoundToInt(-hourHand.transform.eulerAngles.z);
        int minute = Mathf.RoundToInt(-minuteHand.transform.eulerAngles.z);

        // Convert degrees to 12-hour clock time format
        hour = (int)Mathf.Repeat(hour / 30, 12);
        minute = (int)Mathf.Repeat(minute / 6, 60);

        return string.Format("{0:D2}:{1:D2}", hour, minute);
    }
    public int getHouse()
    {
        int hour = Mathf.RoundToInt(-hourHand.transform.eulerAngles.z);

        hour = (int)Mathf.Repeat(hour / 30, 12);

        return hour;
    }
    public int getMinutes()
    {
        int minute = Mathf.RoundToInt(-minuteHand.transform.eulerAngles.z);

       
        minute = (int)Mathf.Repeat(minute / 6, 60);

        return minute;
    }
    public bool checkCorrectHour()
    {
        int hour = Mathf.RoundToInt(-hourHand.transform.eulerAngles.z);
        int minute = Mathf.RoundToInt(-minuteHand.transform.eulerAngles.z);

        // Convert degrees to 12-hour clock time format
        hour = (int)Mathf.Repeat(hour / 30, 12);
        minute = (int)Mathf.Repeat(minute / 6, 60);
        return (hour == correctHour && minute == correctMinute);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }

}

