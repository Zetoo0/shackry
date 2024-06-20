using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    [SerializeField] GameObject _object;

    
    float f(float t)
    {
        t = Mathf.Abs(t);
        return t >= 1.0f ? 0.0f : 1.0f - (3.0f - 2.0f * t) * t * t;
    }

    float Surflet(float x, float y, float grad_x, float grad_y)
    {
        return f(x) * f(y) * (grad_x * x + grad_y * y);
    }

    float Noise(float x, float y)
    {
        float Result = 0.0f;
        int cell_x = Mathf.FloorToInt(x);
        int cell_y = Mathf.FloorToInt(y);

        return Result;
    }
   
}
