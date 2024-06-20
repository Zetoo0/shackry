using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private int screenWidth;
    [SerializeField] private int screenHeight;
    void Start()
    {
        Screen.SetResolution(screenWidth,screenHeight, FullScreenMode.FullScreenWindow);
    }
    
}
