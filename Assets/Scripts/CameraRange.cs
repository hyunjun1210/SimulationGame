using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRange : MonoBehaviour
{
    private void Update()
    {
        float x = Mathf.Clamp(transform.position.x, MapManager.Instance.min.x, MapManager.Instance.max.x);
        float y = Mathf.Clamp(transform.position.y, MapManager.Instance.min.y, MapManager.Instance.max.y);

        transform.position = new Vector3(x, y, -10);
    }
}
