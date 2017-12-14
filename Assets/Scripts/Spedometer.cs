using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spedometer : MonoBehaviour
{

    public Text text;
    public float speed;

    // Use this for initialization
    void Start()
    {
        text = GameObject.Find("Speed").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player 1") != null)
        {
            //gameObject.name;
            /*
            speed = GameObject.Find("Player 1").GetComponent<Rigidbody>().velocity.magnitude;
            string speedString = speed.ToString("F2");
            text.text = "Speed: " + speedString;
            */
        }
    }
}
