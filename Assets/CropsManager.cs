using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Crops
{

}
public class CropsManager : MonoBehaviour
{
    [SerializeField] TileBase plowed;
    [SerializeField] TileBase seeded;
    [SerializeField] Tilemap targetTilemap;

    Dictionary<Vector2Int, Crops> crops;

    private void Start()
    {
        crops = new Dictionary<Vector2Int, Crops>();
    }

    public bool Check(Vector3Int position)
    {
        return crops.ContainsKey((Vector2Int)position);
    }

    public void Seed(Vector3Int position)
    {
        targetTilemap.SetTile(position, seeded);
    }

    public void Plow(Vector3Int position)
    {
        if (crops.ContainsKey((Vector2Int)position))
        {
            return;
        }

        CreatePloweredTile(position);
    }

    private void CreatePloweredTile(Vector3Int position)
    {
        Crops crop = new Crops();
        crops.Add((Vector2Int)position, crop);

        targetTilemap.SetTile((Vector3Int)position, plowed);
    }
}
