using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineTest : MonoBehaviour
{
    LineRenderer lr;
    public Transform[] points;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();

    }

    private void Start()
    {
        SetupLine();
    }

    private void Update()
    {
        LineLine();

    }

    void LineLine()
    {
        for (int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }

    public void SetupLine()
    {
        lr.positionCount = this.points.Length;
    }



}
