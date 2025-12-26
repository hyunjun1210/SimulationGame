using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public enum MapType
{
    Wall,
    Load,
}

public class MapManager : MonoBehaviour
{
    const string PATH = "MapData/";
    [SerializeField] TileBase[] tileBase;
    [SerializeField] GameObject unit;

    public Vector2 minCamera;
    public Vector2 maxCamera;

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

    public void LoadMap(Tilemap tile, string path, int id)
    {
        TextAsset text = Resources.Load<TextAsset>(PATH + path);
        string[] map = text.text.Split('\n');

        int x = int.Parse(map[0]);
        int y = int.Parse(map[1]);


        for (int i = 2; i < y + 2; i++)
        {
            for (int j = 0; j < x; j++)
            {
                string line = map[i][j].ToString();
                if (int.TryParse(line, out int result))
                {
                    if (result != id)
                    {
                        continue;
                    }
                    if (id == 3)
                    {
                        var obj = Instantiate(unit, transform);
                        obj.transform.position = new Vector3Int(j, -(i - 2), 0);
                        continue;
                    }
                    print(result);
                    tile.SetTile(new Vector3Int(j, -(i - 2), 0), tileBase[result]);
                }
            }
        }
        Camera camera = Camera.main;
        float height = camera.orthographicSize;
        float width = height * camera.aspect;
        minCamera = new Vector2(width, -y + height);
        maxCamera = new Vector2(x - width, -height);
    }

    public void LoadMap(Tilemap tile, string path)
    {
        TextAsset text = Resources.Load<TextAsset>(PATH + path);
        string[] map = text.text.Split('\n');

        int x = int.Parse(map[0]);
        int y = int.Parse(map[1]);


        for (int i = 2; i < y + 2; i++)
        {
            for (int j = 0; j < x; j++)
            {
                string line = map[i][j].ToString();
                if (int.TryParse(line, out int result))
                {
                    if (result == 3)
                    {
                        var obj = Instantiate(unit, transform);
                        obj.transform.position = tile.CellToWorld(new Vector3Int(j, -(i - 2), 0));
                        continue;
                    }
                    print(result);
                    tile.SetTile(new Vector3Int(j, -(i - 2), 0), tileBase[result]);
                }
            }
        }
        Camera camera = Camera.main;
        float height = camera.orthographicSize;
        float width = height * camera.aspect;
        minCamera = new Vector2(width, -y + height);
        maxCamera = new Vector2(x - width, -height);
    }

    public void SceneLoad(int sceneCount)
    {
        StartCoroutine(OnSceneLoader(sceneCount));
    }
    public IEnumerator OnSceneLoader(int sceneCount)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneCount);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
