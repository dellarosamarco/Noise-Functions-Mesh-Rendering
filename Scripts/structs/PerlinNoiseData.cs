using UnityEngine;

[System.Serializable]
public struct PerlinNoiseData
{
    public float frequency;
    [Range(1,999)]
    public float scale;
    public int octaves;
    [Range(0f,1f)]
    public float persistance;
    public float lacunarity;
}
