using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{

    [SerializeField] RectTransform crosshair;
    private float currSize = -52.5f;
    private float speed = 10.0f;
    public static bool crosshairWork;

    [SerializeField]Shooting shoot;
    private void Update()
    {
       // UpdateCrosshair();
        //crosshairWork = false;
    }
    
    private void Start()
    {
        crosshairWork = false;
    }

    private void UpdateCrosshair()  
    {
        if (crosshairWork)
        {
            currSize = Mathf.Lerp(currSize, 120.0f, Time.deltaTime * speed);
            print("CrosshairChanged");
        }
        crosshair.sizeDelta = new Vector2(currSize, currSize);
       // crosshairWork = false;
    }

    /*bool IsShot()
    {
        if (Shooting.isShot)
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/
}
