using UnityEngine;

[System.Serializable]
public struct PerlinNoiseData
{
    public float frequency;

    [Range(1,999)]
    public float scale;
}
