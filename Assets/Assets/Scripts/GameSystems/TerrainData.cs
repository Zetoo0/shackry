using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainData : MonoBehaviour {
    [SerializeField] Terrain terrain;
    public static float TerrainWidth;
    public static float TerrainLength;
    public static float TerrainXPos;
    public static float TerrainZPos;

    private void Awake()
    {
        terrain = GetComponent<Terrain>();
    }

    private void Start()
    {
        TerrainWidth = terrain.terrainData.size.x;
        TerrainLength = terrain.terrainData.size.z;

        TerrainXPos = terrain.transform.position.x;
        TerrainZPos = terrain.transform.position.z;
        
        
    }
    
}
