using UnityEngine;

[System.Serializable]
public struct SineNoiseData
{
    public float frequency;
    public int octaves;

    [Range(-0.03f,0f)]
    public float xOctaveOffset;

    [Range(0f, 0.03f)]
    public float yOctaveOffset;

    [Range(0f, 1.5f)]
    public float xPersistance;
    [Range(0f, 1.5f)]
    public float yPersistance;

    [Range(-0.000005f, 0.000005f)]
    public float trajectory;

    public float maxTrajectory;
}
