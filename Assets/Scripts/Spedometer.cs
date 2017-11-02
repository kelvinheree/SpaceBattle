using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spedometer : MonoBehaviour
{

    Text text;
    float speed;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //speed = GameObject.Find("Player").GetComponent<PlayerMover>().currentSpeed;
        string speedString = speed.ToString("F2");
        text.text = "Speed: " + speedString;
    }
}
