using UnityEngine;

[System.Serializable]
public struct BumpsNoiseData
{
    public float frequency;
    public int octaves;
    public Vector2 octaveRandomOffset;
    public float xPersistance;
    public float yPersistance;
}
