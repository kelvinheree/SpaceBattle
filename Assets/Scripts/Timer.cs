using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    Text text;
    float timenew;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        timenew = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        timenew += Time.deltaTime;
        text.text = "Time: " + (int)timenew;
    }
}
