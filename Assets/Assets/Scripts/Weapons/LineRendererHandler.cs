using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererHandler : MonoBehaviour
{
    [SerializeField]private LineRenderer lineR;
    public bool isLineSetUp;

    [Header("Line visibility time")]
    [SerializeField] float lineTime;
    private float startLineTime;
    [SerializeField]Transform playerPos;
    [SerializeField] RectTransform wepPos;
    public Vector3 endPos;
    [SerializeField] private Camera _cam;

    [SerializeField]public Transform shootPos;
   

    private void Start()
    {
        startLineTime = lineTime;
        
    }

    private void Update()
    {
       // Vector3 p_point = _cam.ScreenToWorldPoint(wepPos.position);
        CheckIsLineSetup();
    }
    
    

    private void CheckIsLineSetup()
    {
        if (isLineSetUp)
        {
            if(lineTime >= 0)
            {
                lineR.loop = true;
                lineR.enabled = true;
                lineR.SetPosition(0, shootPos.position);
                lineR.SetPosition(1, endPos);
                playerPos.position = Vector3.Lerp(playerPos.transform.position, endPos, 8.2f * Time.deltaTime);
                lineTime -= Time.deltaTime;
            }
            else
            {
                lineTime = startLineTime;
                lineR.positionCount = 0;
                isLineSetUp = false;
                lineR.enabled = false;
            }
        }
    }

    public void SetupLineStartAndEndPosition(Vector3 endPosi )
    {
        if (isLineSetUp)
        {
            return;
        }

        lineR.positionCount = 2;
        endPos = endPosi;
        isLineSetUp = true;
    }
}
