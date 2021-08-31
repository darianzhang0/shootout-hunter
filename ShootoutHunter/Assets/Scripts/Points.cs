using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public static int points = 0;
    public Text scoreText;

    void Start()
    {
        points = 0; // determine if needed after restart
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = points.ToString();
    }
}
