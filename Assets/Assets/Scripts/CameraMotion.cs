using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraMotion : MonoBehaviour
{

    Camera cam;
    [SerializeField] float zoomFov;
    [SerializeField] float unZoomBasicFov;
    [SerializeField]private bool _shake;
    private Vector3 originalCamPos;
    [SerializeField] private float _frequency;
    [SerializeField] private float _maxShakeTime;
    [SerializeField] private float _shakeTime;
    public enum ZoomState
    {
        Normal,
        Zoom
    };

    ZoomState zoomState;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        unZoomBasicFov = cam.fieldOfView;
        GunGun.onCanShoot += OnAttack;
    }

    private void OnAttack()
    {
        _shake = true;
    }

    void Start()
    {
        zoomState = ZoomState.Normal;
        originalCamPos = cam.transform.localPosition;
        Debug.Log("Original pos: " + originalCamPos);
        Debug.Log("Cam pos: " + cam.transform.localPosition);
    }

    private void Update()
    {
        if (_shake)
        {
            if (_shakeTime < _maxShakeTime)
            {
                Vector3 newPos;
                Vector3 rand = Random.insideUnitCircle;
                newPos.x = originalCamPos.x + rand.x;
                newPos.y = originalCamPos.y + rand.y;
                newPos.z = originalCamPos.z;
                cam.transform.localPosition = newPos * _frequency;
                _shakeTime += Time.deltaTime;
            }
            else
            {
                cam.transform.localPosition = originalCamPos;
                _shake = false;
                _shakeTime = 0f;

            }
        }
    }

    public void OnRightClick()
    {
        switch (zoomState)
        {
            case ZoomState.Normal:
                Zoom();
                break;
                
            case ZoomState.Zoom:
                UnZoom();
                break;

        }
    }

    private void Zoom()
    {
        cam.fieldOfView = zoomFov;
        zoomState = ZoomState.Zoom;

    }

    private void UnZoom()
    {
        cam.fieldOfView = unZoomBasicFov;
        zoomState = ZoomState.Normal;
    }

    

}
