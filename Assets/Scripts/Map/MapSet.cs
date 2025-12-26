using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSet : MonoBehaviour
{
    const string PATH = "MapData/";
    [SerializeField] string mapFileName;

    public void OnLoadScene(int sceneId)
    {
        MapManager.Instance.SceneLoad(sceneId, PATH + mapFileName);
    }
}
