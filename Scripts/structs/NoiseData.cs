using UnityEngine;

[System.Serializable]
public struct NoiseData
{
    public Vector2Int mapSize;
    public float amplitude;
    public Vector2 offset;
    public bool useNoiseCurve;
    public AnimationCurve noiseCurve;
}
