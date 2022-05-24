using UnityEngine;

public static class Circles
{
    public static float[,] generateCirclesNoise(Vector2Int mapSize, float frequency, float amplitude, Vector2 offset, AnimationCurve noiseCurve = null)
    {
        int xSize = mapSize.x;
        int ySize = mapSize.y;

        float[,] circlesNoise = new float[xSize, ySize];

        offset.x -= mapSize.x / 2f;
        offset.y -= mapSize.y / 2f;

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                if (noiseCurve != null)
                    circlesNoise[x, y] = noiseCurve.Evaluate(Mathf.Sin(Mathf.Sqrt(Mathf.Pow(x + offset.x, 2f) + Mathf.Pow(y + offset.y, 2f)) * frequency)) * amplitude;
                else
                    circlesNoise[x, y] = Mathf.Sin(Mathf.Sqrt(Mathf.Pow(x + offset.x, 2f) + Mathf.Pow(y + offset.y, 2f)) * frequency) * amplitude;
            }
        }

        return circlesNoise;
    }
}
