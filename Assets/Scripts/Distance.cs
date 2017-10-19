using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{

    Text text;
    float distance;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    distance = Vector3.Distance(GameObject.Find("Player").transform.position, GameObject.Find("Boundary").transform.position);
    string distanceString = distance.ToString("F2");
    text.text = "Location: "+ distanceString;
    }
}
