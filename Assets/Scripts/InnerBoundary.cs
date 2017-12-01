using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerBoundary : MonoBehaviour
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
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] normals = mesh.normals;
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = -normals[i];
        }
        mesh.normals = normals;
        for(int i = 0; i < mesh.subMeshCount; i++)
        {
            int[] tris = mesh.GetTriangles(i);
            for (int j = 0; j < tris.Length; j+=3)
            {
                int temp = tris[j];
                tris[j] = tris[j + 1];
                tris[j + 1] = temp;
            }
            mesh.SetTriangles(tris, i);
        }

        //Setting constant variables
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
