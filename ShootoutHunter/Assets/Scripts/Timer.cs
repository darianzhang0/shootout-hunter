using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float totalTime = 60.0f;
    public float startWaitTime = 2.0f;
    public Text timer;

    void Start()
    {
        totalTime = 60.0f; // determine if needed after restart
        timer = GetComponent<Text>();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= startWaitTime)
        {
            countdown();
        }

        //Invoke("countdown", 2.0f);
    }

    public void countdown()
    {
        totalTime -= Time.deltaTime;
        timer.text = totalTime.ToString("0");

        if (totalTime < 0)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
