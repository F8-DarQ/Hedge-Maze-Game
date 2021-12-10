using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{
    public Text timerText;
    private float startTime;
    public bool keepTiming;
    public float timer;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Start") {
            StartTimer();
        }

        if(other.gameObject.tag == "Finish") {
            StopTimer();
        }
    }

    void Update() {
        if(keepTiming) {
            UpdateTime();
        }
    }

    void UpdateTime() {
        timer = Time.time - startTime;
        timerText.text = TimeToString(timer);
    }

    float StopTimer() {
        keepTiming = false;
        return timer;
    }

    void ResumeTimer() {
        keepTiming = true;
        startTime = Time.time-timer;
    }

    void StartTimer() {
        keepTiming = true;
        startTime = Time.time;
    }

    string TimeToString(float t) {
        string minutes = ((int) t / 60).ToString("00");
        string seconds = (t % 60).ToString("00");
        string milliseconds = ((int)(t * 100f) % 100).ToString("00");

        return minutes + ":" + seconds + "." + milliseconds;
    }
}
