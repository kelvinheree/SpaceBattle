using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerBoundaryScript : MonoBehaviour
{
    public float timer;
    public float midSize;
    public int midTime;
    public bool grow;
    public float growFactor;


    // Use this for initialization
    void Start()
    {
        //flips normals
        Vector3[] normals = this.GetComponent<MeshFilter>().sharedMesh.normals;
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = -normals[i];
        }


        this.GetComponent<MeshFilter>().sharedMesh.normals = normals; 


        midSize = 50;
        midTime = 10;
        timer = 0f;
        growFactor = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += UnityEngine.Time.deltaTime;
        if (timer > midTime && timer < (midTime + 1))
        {
            grow = true;
        }
        if (grow)
        {
            if (midSize < transform.localScale.x)
            {
                transform.localScale -= new Vector3(1, 1, 1) * UnityEngine.Time.deltaTime * growFactor;
            }
            else
            {
                grow = false;
            }

        }
    }
}
