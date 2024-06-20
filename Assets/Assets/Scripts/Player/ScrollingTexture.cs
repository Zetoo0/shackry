using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
    [SerializeField] float sSx;
    [SerializeField] float sSy;
    [SerializeField] MeshRenderer texture;

    [SerializeField] float windStrong;


    private void Awake()
    {
        texture = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        texture.material.mainTextureOffset = new Vector2(sSx,(sSy * Time.realtimeSinceStartup) / 2);
    }

    private void LateUpdate()
    {
    
    }
}
