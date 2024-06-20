using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{

    Quaternion _rot;
    [SerializeField] float _rotSpeed;

    private void Start()
    {
        _rot = transform.rotation;
    }

    void Update()
    {
        transform.Rotate(0, _rotSpeed * Time.deltaTime / 24, 0);
    }
}
