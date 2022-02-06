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

    public static float width;
    public static float height;

    private void Start()
    {
        GenerateMap();

        // Centering the camera
        Camera.main.transform.position = new Vector3(mapWidth / 2 + .5f, mapHeight / 2 - .5f, -10);

        width = mapWidth;
        height = mapHeight;
        PlacementWheat.SetSize();
    }

    private void GenerateMap()
    {
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                if (i == 0 && j == mapHeight - 1)
                    tilemap.SetTile(new Vector3Int(i, j, 0), tiles[6]);
                else if (i == mapWidth - 1 && j == mapHeight - 1)
                    tilemap.SetTile(new Vector3Int(i, j, 0), tiles[4]);
                else if (j == mapHeight - 1)
                    tilemap.SetTile(new Vector3Int(i, j, 0), tiles[5]);
                else if (i == 0 && j < mapHeight - 1)
                    tilemap.SetTile(new Vector3Int(i, j, 0), tiles[7]);
                else if (i == mapWidth - 1 && j < mapHeight - 1)
                    tilemap.SetTile(new Vector3Int(i, j, 0), tiles[8]);
                else
                    tilemap.SetTile(new Vector3Int(i, j, 0), tiles[0]);
            }
        }
        for (int i = 0; i < mapWidth; i++)
        {
            if (i == 0)
                tilemap.SetTile(new Vector3Int(i, -1, 0), tiles[1]);
            else if (i == mapWidth - 1)
                tilemap.SetTile(new Vector3Int(i, -1, 0), tiles[3]);
            else
                tilemap.SetTile(new Vector3Int(i, -1, 0), tiles[2]);
        }
    }
}
