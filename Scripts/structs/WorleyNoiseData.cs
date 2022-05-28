using UnityEngine;

[System.Serializable]
public struct WorleyNoiseData
{
    public Vector2Int chunks;
    public int pointsPerChunk;
    [Range(0,100)]
    public float spawnRate;
    public Vector2 randomHeightOffset;
}
