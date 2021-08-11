using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

public class ProceduralIsometricMap : MonoBehaviour
{
    [Header("Map Options")]
    public int width = 50;
    public int height = 50;
    public float[,] matrix = new float[1560, 1560];//max size you can change it if you want to
    float scale;
    public float offsetX = 100;
    public float offsetY = 100;
    public Tile grassTile, stoneTile;
    public Tilemap baseGrid;

    [Header("Prefab Options")]
    public string mapName;
    
    public void ClearMap()
    {
        baseGrid.ClearAllTiles();
    }
    public void GenerateMap()
    {
        scale = Mathf.Min(height, width) / 8;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                matrix[x, y] = CalculateHeight(x, y);
                int zDepth = (int)((matrix[x, y] * 10));
                for(int z = 0; z < zDepth; z++)
                {
                    baseGrid.SetTile(new Vector3Int(x, y, z), stoneTile);
                }
                baseGrid.SetTile(new Vector3Int(x, y, zDepth), grassTile);
            }
        }
    }
    public void SaveAsPrefab()
    {
        string prefabPath = "Assets/" + mapName + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(baseGrid.gameObject, prefabPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;
        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
