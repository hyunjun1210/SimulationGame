using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

public enum MapType
{
    Wall,
    Load,
}

public class MapManager : MonoBehaviour
{
    [SerializeField] Tilemap tile;
    [SerializeField] TileBase[] tileBase;
    [SerializeField] GameObject unit;

    public Vector2 minCamera;
    public Vector2 maxCamera;

    public Vector2 minUnit;
    public Vector2 maxUnit;

    static public MapManager Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SceneLoad(int sceneCount, string path)
    {
        SceneManager.LoadScene(sceneCount);
        tile.RefreshAllTiles();
        TextAsset text = Resources.Load<TextAsset>(path);
        string[] map = text.text.Split('\n');

        int x = int.Parse(map[0]);
        int y = int.Parse(map[1]);

        int width = (int)(Camera.main.orthographicSize * Camera.main.aspect);
        int height = (int)Camera.main.orthographicSize;

        Vector3 worldPos = new Vector3(
            Mathf.Ceil(Camera.main.transform.position.x - width),
             Mathf.Ceil(Camera.main.transform.position.y + height),
            0
        );
        Vector3Int startCell = tile.WorldToCell(worldPos);


        for (int i = 2; i < y + 2; i++)
        {
            for (int j = 0; j < x; j++)
            {
                string line = map[i][j].ToString();
                if (int.TryParse(line, out int result))
                {
                    if (result == 3)
                    {
                        Instantiate(unit, transform);
                        continue;
                    }
                    print(result);
                    tile.SetTile(new Vector3Int(startCell.x + j - 1,startCell.y - i - 1 , 0), tileBase[result]);
                }
            }
        }
        worldPos = tile.CellToWorld(startCell);
       //나중에 크기 문제 생기면 변경
       float mapTopY = worldPos.y - 2;
       minCamera.x = worldPos.x + width;
       maxCamera.x = worldPos.x + x  - width - 2;
       minCamera.y = (mapTopY - y) + height;
       maxCamera.y = mapTopY - height;

        minUnit.x = worldPos.x;
        maxUnit.x = worldPos.x + x;
        minUnit.y = mapTopY - y;
        maxUnit.y = mapTopY;
    }
}
