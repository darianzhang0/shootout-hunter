using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text finalScoreText;
    public AudioSource GoodEnd;
    public AudioSource BadEnd;

    void Start()
    {
        finalScoreText = GetComponent<Text>();
        finalScoreText.text = Points.points.ToString();

        if (Points.points < 0)
        {
            Debug.Log("bad " + Points.points);
            BadEnd.Play();

            //FindObjectOfType<AudioManager>().Play("BadEnd");
        }

        else
        {
            Debug.Log("good " + Points.points);
            GoodEnd.Play();

            //FindObjectOfType<AudioManager>().Play("GoodEnd");
        }
    }
}
