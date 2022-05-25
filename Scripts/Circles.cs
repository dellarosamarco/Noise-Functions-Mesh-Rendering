using UnityEngine;

public static class Circles
{
    public static float[,] generateCirclesNoise(
        Vector2Int mapSize, 
        float frequency, 
        float amplitude, 
        Vector2 offset, 
        int octaves,
        Vector2 octaveRandomOffset,
        AnimationCurve noiseCurve = null
    )
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
                float _x = x;
                float _y = y;
                for (int i = 0; i < octaves; i++)
                {
                    _x += Random.Range(octaveRandomOffset.x, octaveRandomOffset.y);
                    _y += Random.Range(octaveRandomOffset.x, octaveRandomOffset.y);
                }

                if (noiseCurve != null)
                    circlesNoise[x, y] = noiseCurve.Evaluate(Mathf.Sin(Mathf.Sqrt(Mathf.Pow(_x + offset.x, 2f) + Mathf.Pow(_y + offset.y, 2f)) * frequency)) * amplitude;
                else
                    circlesNoise[x, y] = Mathf.Sin(Mathf.Sqrt(Mathf.Pow(_x + offset.x, 2f) + Mathf.Pow(_y + offset.y, 2f)) * frequency) * amplitude;
            }
        }

        return circlesNoise;
    }
}
