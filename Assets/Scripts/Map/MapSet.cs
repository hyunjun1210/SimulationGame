using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSet : MonoBehaviour
{
    public void OnLoadScene(int sceneId)
    {
        MapManager.Instance.SceneLoad(sceneId);
    }
}
