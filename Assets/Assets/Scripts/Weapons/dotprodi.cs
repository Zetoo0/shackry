using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotprodi : MonoBehaviour
{

    public static float CalculateDotProduct(Vector3 a, Vector3 b)
    {
        return VectorMultiply(a, b);
    }
    


    public static float VectorMultiply(Vector3 a, Vector3 b)            
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;   
    }

    public static float VectorLength(Vector3 a)
    {
        return Mathf.Sqrt((a.x * a.x) + (a.y * a.y) + (a.z * a.z));
    }

}
