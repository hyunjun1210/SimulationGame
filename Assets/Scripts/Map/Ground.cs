using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ground : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] string mapFileName;

    void Start()
    {
        MapManager.Instance.LoadMap(tilemap, mapFileName);
    }
}
