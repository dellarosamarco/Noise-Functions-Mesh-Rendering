using UnityEngine;

[System.Serializable]
public struct SineNoiseData
{
    public float frequency;
    public int octaves;
    public Vector2 octaveRandomOffset;

    [Range(0f, 1.5f)]
    public float xPersistance;
    [Range(0f, 1.5f)]
    public float yPersistance;
}
