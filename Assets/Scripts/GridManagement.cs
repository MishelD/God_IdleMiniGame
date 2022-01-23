using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManagement : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile[] tiles;
    [SerializeField] private int mapWidth;
    [SerializeField] private int mapHeight;

    private void Start()
    {
        GenerateMap();

        // Centering the camera
        Camera.main.transform.position = new Vector3(mapWidth / 2 + .5f, mapHeight / 2 - .5f, -10);
    }

    private void GenerateMap()
    {
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                tilemap.SetTile(new Vector3Int(i, j, 0), tiles[Mathf.RoundToInt(Random.Range(0, 2))]);
            }
        }
        for (int i = 0; i < mapWidth; i++)
        {
            tilemap.SetTile(new Vector3Int(i, -1, 0), tiles[Mathf.RoundToInt(Random.Range(4, 6))]);
        }
    }

}
