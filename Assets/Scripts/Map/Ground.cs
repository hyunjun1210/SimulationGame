using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ground : MonoBehaviour
{
    [SerializeField] Tilemap[] tilemap;
    [SerializeField] string mapFileName;

    void Start()
    {
        MapManager.Instance.LoadMap(tilemap[0], mapFileName, 0);
        MapManager.Instance.LoadMap(tilemap[1], mapFileName, 1);
        MapManager.Instance.LoadMap(tilemap[0], mapFileName, 2);
        MapManager.Instance.LoadMap(null, mapFileName, 3);
    }
}
