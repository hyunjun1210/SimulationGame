using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRange : MonoBehaviour
{
    private void Update()
    {
        float x = Mathf.Clamp(transform.position.x, MapManager.Instance.minCamera.x, MapManager.Instance.maxCamera.x);
        float y = Mathf.Clamp(transform.position.y, MapManager.Instance.minCamera.y, MapManager.Instance.maxCamera.y);

        transform.position = new Vector3(x, y, -10);
    }
}
